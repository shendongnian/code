    class Program
    {
        public string read()
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            try
            {
                HtmlAgilityPack.HtmlDocument document = htmlWeb.Load("http://www.yahoo.com");
                return document.DocumentNode.InnerHtml;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e.ToString());
                return null;     
            }
        }     
    
        static void Main(string[] args)
        {
            Program dis = new Program();
            string text = dis.read();
            Console.WriteLine(text);
            Console.ReadLine();        
        }
    }
