    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    
    namespace testapp_xdocument_linq
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                XNamespace ns = "http://schemas.microsoft.com/developer/msbuild/2003";
                XDocument X = XDocument.Load("C:\\Users\\Brian\\Documents\\Visual Studio 2012\\Projects\\testapp_xdocument_linq\\testapp_xdocument_linq\\testapp_xdocument_linq.csproj");
                
                var PropertyGroups = from PG in X.Descendants(ns + "PropertyGroup") select PG;
    
                //Print Results
                foreach (var element in PropertyGroups)
                {
                    Console.WriteLine("First Descendant Name: " + element.Descendants().First().Name + Environment.NewLine);
                }
    
                Console.ReadLine();
            }
        }
    }
