    public static void Main()
    {
        using (StringWriter sw = new StringWriter())
        {
            using (XmlWriter xw = XmlWriter.Create(sw))
            {
                xw.WriteStartElement("c1");
                xw.WriteString(string.Empty);
                xw.WriteFullEndElement();
            }
            Console.Write(sw.ToString());  // Prints <c1></c1>
        }
    }
