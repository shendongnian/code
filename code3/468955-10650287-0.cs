    class Program
    {
        static XElement CreateXml()
        {
            System.Threading.Thread.Sleep(1000);
            return XElement.Parse(@"<FooBar>Hi!</FooBar>");
        }
        static void ProceedXml(XElement xml)
        {
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine(xml.ToString());
        }
        public static void Main()
        {
            Task.Factory.StartNew<XElement>(CreateXml)
                        .ContinueWith(t => ProceedXml(t.Result));
            Console.ReadKey();
        }
    }
