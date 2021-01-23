    class Program
    {
        static void Main(string[] args)
        {
            string xml = "<Response xmlns=\"someurl\" xmlnsLi=\"thew3url\">"
                       + "<ErrorCode></ErrorCode>"
    + "<Status>Success</Status>"
    + "<Result>"
    + "<Manufacturer>"
                + "<ManufacturerID>46</ManufacturerID>"
                + "<ManufacturerName>APPLE</ManufacturerName>"
    + "</Manufacturer>"
    + "</Result>"
    + "</Response>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            var root = doc.FirstChild;
            for (int i = root.ChildNodes.Count - 1; i >= 0; i--)
            {
                root.RemoveChild(root.ChildNodes[i]);
            }
            Console.WriteLine(doc.InnerXml);
            Console.ReadKey();
        }
    }
