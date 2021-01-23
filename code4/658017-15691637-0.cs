    using System;
    using System.Dynamic;
    using System.Xml.Linq;
    using Microsoft.CSharp.RuntimeBinder;
    using System.Linq;
    
    namespace ConsoleApplication8
    {
        class Program
        {
            static void Main(string[] args)
            {
                XDocument document = XDocument.Load("SessionStateInfo.xml");
                XNamespace nameSpace = document.Root.GetDefaultNamespace();
                XElement node = document.Descendants(nameSpace + "DefinitionName").FirstOrDefault();   
    
                if (node != null)
                {
                    Console.WriteLine("Cool! XDocument rocks! value: {0}", node.Value);
                }
                else
                {
                    Console.WriteLine("Spoot! Didn't find it!");
                }
            }      
        }       
    }
