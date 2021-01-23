            XmlSerializer xs = new XmlSerializer(typeof(MovieRunTimes));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("a", "http://schemas.microsoft.com/2003/10/Serialization/Arrays");
            string result = null;
            using(StringWriter writer = new StringWriter())
            {
                xs.Serialize(writer,mrt,ns);
                result = writer.ToString();
            }
