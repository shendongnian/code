    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace testStackOverflow
    {
    class Program
    {
        static void Main(string[] args)
        {
            //Load xml
            XDocument xdoc = XDocument.Load("test.xml");
            //Run query
            var lv1s = from lv1 in xdoc.Descendants("Video")
                       select new
                       {
                           title = lv1.Element("Title").Value
                       };
            //Loop through results
            foreach (var lv1 in lv1s)
            {
                Console.WriteLine(lv1.title);
            }
            Console.ReadLine();
        }
    }
    }
