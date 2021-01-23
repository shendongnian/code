    class Program {
        static void Main(string[] args) {
            StringReader sr = new StringReader("<?xml version=\"1.0\"?><Style Width=\"1024\" Height=\"768\"><BaseStyle Width=\"1024\" Height=\"768\" BackgroundPath=\"./Images/BackgroundBBB.png\"/><Styles><LabelStyle ID=\"Label1\" Font=\"Arial\" Bold=\"true\" /> <!-- exists in both --><LabelStyle ID=\"Label2\" Font=\"Arial\" /> <!-- exists in both --><LabelStyle ID=\"Label3\" Font=\"Arial\" Bold=\"false\" /> <!-- unique --></Styles></Style>"); 
            XDocument xdoc1 = XDocument.Load(sr);
            sr.Close();
            sr = new StringReader("<?xml version=\"1.0\"?><Style Width=\"1024\" Height=\"768\"><BaseStyle Width=\"1024\" Height=\"768\" BackgroundPath=\"./Images/BackgroundBBB.png\"/><Styles><LabelStyle ID=\"Label1\" Font=\"Arial\" Bold=\"true\" /> <!-- exists in both --><LabelStyle ID=\"Label2\" Font=\"Arial\" /> <!-- exists in both --><LabelStyle ID=\"Label4\" Font=\"Arial\" Bold=\"false\" /> <!-- unique --></Styles></Style>");
            XDocument xdoc2 = XDocument.Load(sr);
            sr.Close();
            sr = new StringReader("<?xml version=\"1.0\"?><Style Width=\"1024\" Height=\"768\"><BaseStyle Width=\"1024\" Height=\"768\" BackgroundPath=\"./Images/BackgroundBBB.png\"/><Styles></Styles></Style>");
            XDocument xDocDest = XDocument.Load(sr);
            sr.Close();
            XElement xeDest = xDocDest.Root.Descendants("Styles").Single();
            XElement[] x2s = (from x in xdoc2.Root.Descendants("LabelStyle") orderby x.Attribute("ID").Value select x).ToArray() ;
            Int32 iCurrentX2 = 0;
            XElement xeCurrentX2 = (x2s.Count() > 1) ? x2s[0] : null;
            foreach (XElement x1 in from x in xdoc1.Root.Descendants("LabelStyle") orderby x.Attribute("ID").Value select x) {
                if ( String.Compare(x1.Attribute("ID").Value, xeCurrentX2.Attribute("ID").Value) < 0) {
                    xeDest.Add(x1);
                } else {
                    while (iCurrentX2 < x2s.Count() && String.Compare(x1.Attribute("ID").Value, xeCurrentX2.Attribute("ID").Value) < 0) {
                        xeDest.Add(xeCurrentX2);
                        xeCurrentX2 = x2s[++iCurrentX2];
                    }
                }
            }
            while (iCurrentX2 < x2s.Count()) {
                xeDest.Add(x2s[iCurrentX2++]);
            }
            Console.WriteLine(xDocDest.ToString());
        }
    }
