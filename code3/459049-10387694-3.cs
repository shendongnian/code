        public static void SerializeFile(String filename, object obj, bool deleteIfExists = true)
        {
            if (deleteIfExists)
            {
                FileManager.DeleteFile(filename);
            }
            Type[] extraTypes = ClassHandler.GetPropertiesTypes(obj, true);
            using (var stream = new FileStream(filename, FileMode.Create))
            {
                //XmlSerializer xmlSerialize = new XmlSerializer(obj.GetType(), extraTypes); 
                XmlSerializer xmlSerialize = new XmlSerializer(obj.GetType(), GetXmlAttributeOverrides(obj.GetType()), extraTypes, null, null);
                xmlSerialize.Serialize(stream, obj);
            }
        }
