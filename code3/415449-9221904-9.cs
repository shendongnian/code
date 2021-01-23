        private static void Measure(string functionName, int iterations, Action implementation)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < iterations; i++)
            {
                implementation();
            }
            watch.Stop();
            Console.WriteLine("{0}: {1}ms", functionName, watch.ElapsedMilliseconds);
        }
        private static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"location of some large and complex XML file");
            string referenceXPath = "/vps/vendorProductSets/vendorProductSet/product[100]/prodName/locName";
            Measure("UsingPreviousSiblings", 10000,
                    () =>
                        {
                            XmlElement target = doc.SelectSingleNode(referenceXPath) as XmlElement;
                            Debug.Assert(referenceXPath == target.GetXPath_UsingPreviousSiblings());
                        });
            Measure("SequentialIteration", 10000,
                    () =>
                    {
                        XmlElement target = doc.SelectSingleNode(referenceXPath) as XmlElement;
                        Debug.Assert(referenceXPath == target.GetXPath_SequentialIteration());
                    });
            Measure("ByPosition", 10000,
                    () =>
                    {
                        XmlElement target = doc.SelectSingleNode(referenceXPath) as XmlElement;
                        Debug.Assert(referenceXPath == target.GetXPath_ByPosition());
                    });
        }
    }
