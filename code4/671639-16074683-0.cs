    class Program
    {
        static void Main(string[] args)
        {
            // Create the query 
            var nodes = from appNode in XElement.Load("App.config").Descendants("appSettings").Elements()
                        where appNode.Attribute("key").Value == "domain"
                        select appNode;
            var element = nodes.FirstOrDefault();
            string value = element.Attribute("value").Value;
            Console.WriteLine(value);
           
            //Pause the application 
            Console.ReadLine();
        }
    }
