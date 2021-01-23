    // main program
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Collections;
    using System.Xml.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public static void Main()
            {
                XDocument doc = XDocument.Parse(@"<Records> <record id='818591'/> <record id='818592'/> <record id='818593'/> <record id='818594'/> <record id='818595'/> <record id='818596'/> <record id='818597'/> <record id='818598'/></Records>");
    
                foreach (string s in doc.Descendants().Attributes("id").Select(a => a.Value))
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
