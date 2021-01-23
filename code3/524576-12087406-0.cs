        static void Main(string[] args)
        {
            XmlDocument x = new XmlDocument();
            x.Load("exp.xml");
            PrintNode(x.DocumentElement);
        }
        private static void PrintNode(XmlNode x)
        {
            if (!x.HasChildNodes)
                Console.Write(string.Format("{0} ", x.InnerText));
            for (int i = 0; i < x.ChildNodes.Count; i++)
            {
                PrintNode(x.ChildNodes[i]);
            }
        }
