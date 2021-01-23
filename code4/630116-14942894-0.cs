    class Program
    {
        static void Main(string[] args)
        {
            var test = new AnotherXmlTest();
            test.readPortfolio("filename");
            //Put a break on this line and instect object 'test'
            Console.ReadLine();
        }
    }
    public class AnotherXmlTest
    {
        public const string xml = @"<portfolio><transaction><ticker>GOOG</ticker><action>buy</action><date>20071116</date><shares>44</shares></transaction></portfolio>";
        public class Transaction
        {
            public string ticker { get; set; }
            public string action { get; set; }
            public string date { get; set; }
            public int numShares { get; set; }
            public double price { get; set; }
        }
        List<Transaction> transList = new List<Transaction>();
        public void readPortfolio(string filename)
        {
            //Use this instead!
            //XmlTextReader reader = new XmlTextReader(filename);
            //XDocument xDoc = XDocument.Load(reader);
            XDocument xDoc = XDocument.Parse(xml);
            transList.AddRange(from transaction in xDoc.Descendants("transaction")
                               select new Transaction
                               {
                                   ticker = transaction.Element("ticker").Value,
                                   action = transaction.Element("action").Value,
                                   date = transaction.Element("date").Value,
                                   numShares = Convert.ToInt32(transaction.Element("shares").Value)
                                   // No price?? 
                               });
        }
    }
