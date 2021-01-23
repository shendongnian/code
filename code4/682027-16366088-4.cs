            public static void WriteSettingsAsXml(string destinationPath, Type objectType, object objectValue, bool hideNamespaces)
            {
                XmlSerializer serializer = new XmlSerializer(objectType);
                using (TextWriter writer = new StreamWriter(destinationPath))
                {
                    if (hideNamespaces)
                    {
                        XmlSerializerNamespaces hiddenNamespaces = new XmlSerializerNamespaces();
                        hiddenNamespaces.Add("", "");
                        serializer.Serialize(writer, objectValue, hiddenNamespaces);
                    }
                    else
                        serializer.Serialize(writer, objectValue);
                    writer.Close();
                }
            }
            public static object ReadSettingsFromXml(string xmlFilePath, Type objectType)
            {
                XmlSerializer serializer = new XmlSerializer(objectType);
                using (FileStream fileStream = new FileStream(xmlFilePath, FileMode.Open))
                {
                    return serializer.Deserialize(fileStream);
                }
            }
        }
    }
