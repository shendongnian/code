        static void Main(string[] args)
        {
            string Input = "Hola";
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("http://www.google.com/translate_t?hl=en&ie=UTF8&text=Hola&langpair=es|en");
            string definition = doc.DocumentNode.SelectSingleNode(string.Format("//span[@title='{0}']",Input)).InnerText;
            Console.WriteLine(definition);
            Console.ReadKey();
        }
