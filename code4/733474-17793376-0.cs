    public struct Rule
    {
        public String keyDB;
        public String eventLog;
    }
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xdoc = XDocument.Load("src.xml");
            ILookup<string, Rule> lookup = xdoc.Descendants("Error").ToLookup(x => x.Attribute("code").Value, x => new Rule() { keyDB = x.Element("KeyDB").Value, eventLog = x.Element("EventLog").Value });
            //Perform operation based on the error code from the lookup
            Console.Read();
        }
    }
