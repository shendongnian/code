    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var dom = new MSXML2.DOMDocument30();
                dom.async = false;
                dom.load(args[0]);
                var xslt = new MSXML2.DOMDocument30();
                xslt.async = false;
                xslt.load(args[1]);
                File.WriteAllText(args[2], dom.transformNode(xslt));
                Console.WriteLine("Done");
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
