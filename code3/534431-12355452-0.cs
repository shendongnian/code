    class Program {
        static void Main(string[] args) {
            StringReader sr = new StringReader("<?xml version=\"1.0\"?><Style Width=\"1024\" Height=\"768\"><BaseStyle Width=\"1024\" Height=\"768\" BackgroundPath=\"./Images/BackgroundBBB.png\"/><Styles><LabelStyle ID=\"Label1\" Font=\"Arial\" Bold=\"true\" /> <!-- exists in both --><LabelStyle ID=\"Label2\" Font=\"Arial\" /> <!-- exists in both --><LabelStyle ID=\"Label3\" Font=\"Arial\" Bold=\"false\" /> <!-- unique --></Styles></Style>"); 
            XDocument xdoc1 = XDocument.Load(sr);
            sr.Close();
            sr = new StringReader("<?xml version=\"1.0\"?><Style Width=\"1024\" Height=\"768\"><BaseStyle Width=\"1024\" Height=\"768\" BackgroundPath=\"./Images/BackgroundBBB.png\"/><Styles><LabelStyle ID=\"Label1\" Font=\"Arial\" Bold=\"true\" /> <!-- exists in both --><LabelStyle ID=\"Label2\" Font=\"Arial\" /> <!-- exists in both --><LabelStyle ID=\"Label4\" Font=\"Arial\" Bold=\"false\" /> <!-- unique --></Styles></Style>");
            XDocument xdoc2 = XDocument.Load(sr);
            sr.Close();
            IEnumerable<String> l1 = from x1 in xdoc1.Root.Descendants("LabelStyle") select x1.Attribute("ID").Value;
            
            IEnumerable<XElement> xes =
                from x in xdoc2.Root.Descendants("LabelStyle")
                where !l1.Contains(x.Attribute("ID").Value)
                select x;
            XElement destXE = xdoc1.Root.Descendants("Styles").First();
            foreach (XElement xe in xes) {
                destXE.Add(xe);
            }
            Console.WriteLine(xdoc1.ToString());
        }
    }
