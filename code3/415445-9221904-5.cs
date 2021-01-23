    internal class Program
    {
        private static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"location of some large and complex XML file");
            string referenceXPath = "/vps/vendorProductSets/vendorProductSet/product[100]/prodName/locName";
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 10000; i++)
            {
                XmlElement target = doc.SelectSingleNode(referenceXPath) as XmlElement;
                Debug.Assert(referenceXPath == target.GetXPath_UsingPreviousSiblings());
            }
            watch.Stop();
            Console.WriteLine("UsingPreviousSiblings: " + watch.ElapsedMilliseconds + "ms");
            watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 10000; i++)
            {
                XmlElement target = doc.SelectSingleNode(referenceXPath) as XmlElement;
                Debug.Assert(referenceXPath == target.GetXPath_SequentialIteration());
            }
            watch.Stop();
            Console.WriteLine("  SequentialIteration: " + watch.ElapsedMilliseconds + "ms");
        }
    }
