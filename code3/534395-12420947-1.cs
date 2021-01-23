    public void ImportData(NHCfg.Configuration config, ISessionFactory factory, string dataFile)
    {
        using (var zip = new ZipFile(dataFile))
        using (var session = factory.OpenSession())
        using (var tx = session.BeginTransaction())
        {
            var filesAndMaps = from file in zip.EntryFileNames
                               join map in config.ClassMappings on Path.GetFileNameWithoutExtension(file) equals map.EntityName
                               select new { Filename = file, Entitymap = map };
            foreach (var fileAndMap in filesAndMaps)
            {
                using (Stream stream = zip[fileAndMap.Filename].OpenReader())
                using (StreamReader reader = new StreamReader(stream))
                {
                    // mapping der Klasse
                    var classMetadata = factory.GetClassMetadata(fileAndMap.Entitymap.EntityName);
                    var propertyNames = reader.ReadLine().Split(SEPERATOR[0]).Select(str => str.EndsWith("_Id") ? str.Remove(str.Length - "_Id".Length) : str).ToArray();
                    // propertyNamen(/pfade) und typen aus dem mapping holen
                    List<string> names = new List<string>();
                    List<IType> itypes = new List<IType>();
                    names.AddRange(classMetadata.PropertyNames);
                    itypes.AddRange(classMetadata.PropertyTypes);
                    for (int index = names.Count - 1; index >= 0; index--)
                    {
                        var propertyType = itypes[index];
                        if (propertyType.IsComponentType)
                        {
                            var basename = names[index];
                            var componentType = (ComponentType)propertyType;
                            names.RemoveAt(index);
                            names.InsertRange(index, componentType.PropertyNames.Select(name => basename + "." + name));
                            itypes.RemoveAt(index);
                            itypes.InsertRange(index, componentType.Subtypes);
                            index += componentType.Subtypes.Length;
                        }
                        else if (propertyType.IsEntityType)
                        {
                            itypes[index] = factory.GetClassMetadata(((EntityType)propertyType).GetAssociatedEntityName()).IdentifierType;
                        }
                    }
                    // mit den namen aus der csv abgleichen um den index im array der namen und typen zu bestimmen
                    int[] indices = new int[propertyNames.Length];
                    for (int i = 0; i < indices.Length; i++)
                    {
                        indices[i] = names.IndexOf(propertyNames[i]);
                    }
                    object[] deserialisedValues = new object[itypes.Count];
                    object[] objectValues = new object[classMetadata.PropertyTypes.Length];
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] serialisedValues = line.Split(SEPERATOR[0]);
                        // Werte deserialisieren
                        for (int i = 0; i < serialisedValues.Length; i++)
                        {
                            // nur deserialisieren wenn es das property überhaupt noch gibt
                            if (indices[i] >= 0)
                                deserialisedValues[indices[i]] = Deserialize(serialisedValues[i], itypes[indices[i]].ReturnedClass);
                        }
                        int offset = 0;
                        for (int i = 0; i < objectValues.Length; i++)
                        {
                            var propertyType = classMetadata.PropertyTypes[i];
                            if (propertyType.IsComponentType)
                            {
                                objectValues[i] = ToComponentObject(deserialisedValues, ref offset, (ComponentType)propertyType, session);
                            }
                            else
                            {
                                objectValues[i] = (propertyType.IsEntityType && deserialisedValues[offset] != null) ?
                                    session.Load(((ManyToOneType)propertyType).GetAssociatedEntityName(), deserialisedValues[offset]) :
                                    deserialisedValues[offset];
                                offset++;
                            }
                        }
                        object entity = classMetadata.Instantiate(null, EntityMode.Poco);
                        classMetadata.SetPropertyValues(entity, objectValues, EntityMode.Poco);
                        session.Save(entity);
                    }
                }
            }
            tx.Commit();
        }
    }
