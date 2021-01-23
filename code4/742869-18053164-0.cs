    class Program
    {
        static void Main(string[] args)
        {
            String parameter =
                @"<HostName>Arasanalu</HostName>
                  <AdminUserName>Administrator</AdminUserName>
                  <AdminPassword>A1234</AdminPassword>
                  <PlaceNumber>38</PlaceNumber>";
            var ds = new DataSet();
            ds.ReadXml(new StringReader("<root>" + parameter + "</root>"), 
                XmlReadMode.InferSchema);
            var sb = new StringBuilder();
            using (var w = new StringWriter(sb))
            {
                ds.WriteXmlSchema(w);
            }
            Console.WriteLine(sb.ToString());
        }
    }
