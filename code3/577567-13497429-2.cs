        static string ToXml(object input)
        {
            string output;
            XmlSerializer serializer = new XmlSerializer(input.GetType());
            StringBuilder sb = new StringBuilder();
            using (XmlWriter xw = XmlWriter.Create(sb))
            {
                serializer.Serialize(xw, input);
            }
            output = sb.ToString();
            return output;
        }
