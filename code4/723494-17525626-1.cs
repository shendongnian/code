     public static string SerializeObject(Object obj)
            {
                var toReturn = string.Empty;
                try
                {
                    var ms = new MemoryStream();
                    var xs = new XmlSerializer(obj.GetType());
                    var xmlTextWriter = new XmlTextWriter(ms, Encoding.UTF8);
                    xs.Serialize(xmlTextWriter, obj);
                    toReturn = new UTF8Encoding().GetString((((MemoryStream)xmlTextWriter.BaseStream).ToArray()));
                }
                catch (Exception)
                {
                    throw; //???
                }
    
                return toReturn;
    
            }
