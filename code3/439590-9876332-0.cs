    class Program
    {
        static void Main()
        {
            XDocument doc = new XDocument(new XElement("test", 
                HttpUtility.HtmlDecode("caf&eacute;")));
            
            Console.WriteLine(doc);
            Console.ReadKey();
        }
    }
    
