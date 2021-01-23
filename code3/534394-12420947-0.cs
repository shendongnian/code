    ExportData(config, config.BuildSessionFactory(), dataFile, config.ClassMappings.Select(m => m.EntityName));
    public void ExportData(Configuration config, ISessionFactory factory, string dataFile, IEnumerable<string> entitiesToExport)
    {
        File.Delete(dataFile);
        using (var zip = new ZipFile(dataFile) { CompressionMethod = CompressionMethod.Deflate, CompressionLevel = CompressionLevel.BestCompression })
        using (var session = factory.OpenStatelessSession())
        using (var tx = session.BeginTransaction())
        {
            foreach (var name in entitiesToExport)
            {
                // copy for closure
                var entityName = name;
                zip.AddEntry(entityName + ".csv", (tablename, outstream) =>
                {
                    using (var writer = new StreamWriter(outstream))
                    {
                        // mapping der Klasse
                        var entityMap = config.GetClassMapping(entityName);
                        // only properties, no Collections (toMany)
                        var properties = entityMap.PropertyClosureIterator.Where(prop => prop.ColumnSpan > 0).ToArray();
                        // write csv(tsv) header
                        writer.WriteLine(string.Join(SEPERATOR, ToPropertyNames(properties)));
                        var classMetaData = factory.GetClassMetadata(entityName);
                        const int pagesize = 10000;
                        int page = 0;
                        IList<object> objects;
                        do
                        {
                            objects = session.CreateCriteria(entityName)
                                .SetFirstResult(page * pagesize)
                                .SetMaxResults(pagesize)
                                .AddOrder(Order.Asc(Projections.Id()))
                                .List<object>();
                            foreach (var obj in objects)
                            {
                                // get property values as string
                                var values = ToPropertyValues(factory, classMetaData, properties, string.Empty, obj).Select(Serialize);
                                writer.WriteLine(string.Join(SEPERATOR, values));
                            }
                            page++;
                        } while (objects.Count > 0);
                    }
                });
            }
            zip.Save(dataFile);
        }
    }
