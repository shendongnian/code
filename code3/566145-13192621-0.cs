    public static partial class ObjectXMLSerializer<T> where T : class
    {
                private static void SaveToDocumentFormat(T serializableObject, System.Type[] extraTypes, string path, IsolatedStorageFile isolatedStorageFolder)
                {
                    using (TextWriter textWriter = CreateTextWriter(isolatedStorageFolder, path))
                    {
                        XmlSerializer xmlSerializer = CreateXmlSerializer(extraTypes);
        
                        //Cuong: set name space to null
                        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                        ns.Add("", "");
                        xmlSerializer.Serialize(textWriter, serializableObject, ns);
                    }
                }
                public static void Save(T serializableObject, string path)
                {
                        SaveToDocumentFormat(serializableObject, null, path, null);
                }
    }
