            StringBuilder sb = new StringBuilder();
            using ( var writer = new IdentifierXmlWriter(new StringWriter(sb)))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(identifiers.GetType(), new XmlRootAttribute("Identifiers"));
                xmlSerializer.Serialize(writer, identifiers);
            }
            Console.WriteLine(sb.ToString());
