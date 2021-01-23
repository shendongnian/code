    using System;
    using System.Collections.Generic;
    using System.Reflection;
    class Program
    {
        static void Main(string[] args)
        {
            var log = new XmlLog();
            var values = new Dictionary<string, string> { { "Hello", "1" }, { "World", "2" } };
            foreach (var methodInfo in typeof(XmlLog).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                methodInfo.SetValue(log, values[methodInfo.Name]);
            }
            
            Console.WriteLine(log.Hello);
            Console.WriteLine(log.World);
        }
        class XmlLog
        {
            public string Hello { get; set; }
            public string World { get; set; }
        }
    }
