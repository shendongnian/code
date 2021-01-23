    using System;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    namespace TestLINQ_Xml
    {
        class Program
        {
            static void Main(string[] args)
            {
                Test();
            }
    
            static void Test()
            {
                string xml = 
    @"<root>
        <Manager name='1'>
            <Manager name='2'>
                <Employee name='3'/>
            </Manager>
            <Manager name='abe'>
            </Manager>
            <Employee name='4'/>
            <Employee name='5'/>
        </Manager>
    </root>";
                XElement top = XElement.Parse(xml);
    
                XElement cliked1 = top;
                XElement res1 = TestLinqXpath.TestLinqXpath.SelectNearestDescendantEmployee(cliked1);
                Console.WriteLine(res1.ToString());
    
                XElement cliked2 = top.XPathSelectElement("Manager[@name='1']");
                XElement res2 = TestLinqXpath.TestLinqXpath.SelectNearestDescendantEmployee(cliked2);
                Console.WriteLine(res2.ToString());
    
                XElement cliked3 = top.XPathSelectElement(".//Manager[@name='2']");
                XElement res3 = TestLinqXpath.TestLinqXpath.SelectNearestDescendantEmployee(cliked3);
                Console.WriteLine(res3.ToString());
    
                XElement cliked4 = top.XPathSelectElement(".//Manager[@name='abe']");
                XElement res4 = TestLinqXpath.TestLinqXpath.SelectNearestDescendantEmployee(cliked4);
                Console.WriteLine((res4 != null) ? res4.ToString() : "null");
    
                XElement cliked5 = top.XPathSelectElement(".//Employee[@name='5']");
                XElement res5 = TestLinqXpath.TestLinqXpath.SelectNearestDescendantEmployee(cliked5);
                Console.WriteLine(res5.ToString());
            }
        }
    }
