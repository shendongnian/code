    public static void CopyIdenticalObjects(object source, object destination)
            {
                FieldInfo[] destinationFields = destination.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
    
                foreach (FieldInfo sourceField in source.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
                    for (int counter = 0; counter < destinationFields.Length; ++counter)
                        try
                        {
                            if (destinationFields[counter].Name.Equals(sourceField.Name))
                            {
                                destinationFields[counter].SetValue(destination, sourceField.GetValue(source));
                                break;
                            }
                        }
                        catch { }
            }
