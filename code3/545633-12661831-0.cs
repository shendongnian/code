    using System;
    using System.IO;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    class TestXPath
    {
        static void Main(string[] args)
        {
    
            string xml1 =
    @"<t>
     <a b='attribute value'/> 
     <c>
       <b>element value</b>
     </c>
     <e b='attribute value'/>
    </t>";
    
            string xml2 =
    @"<t>
     <c>
       <b>element value</b>
     </c>
     <e b='attribute value'/>
    </t>";
    
            TextReader sr = new StringReader(xml1);
            XDocument xdoc = XDocument.Load(sr, LoadOptions.None);
    
            string result1 = xdoc.XPathEvaluate("string(/*/*/@b | /*/*/b)") as string;
    
            TextReader sr2 = new StringReader(xml2);
            XDocument xdoc2 = XDocument.Load(sr2, LoadOptions.None);
    
            string result2 = xdoc2.XPathEvaluate("string(/*/*/@b | /*/*/b)") as string;
    
            Console.WriteLine(result1);
            Console.WriteLine(result2);
    
    
        }
    }
