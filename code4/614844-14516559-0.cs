    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    
    namespace ConsoleApplication1
    {
        public class TestRemove
        {
            public static void Main() {
                Console.WriteLine("----OLD TREE STARTS---");
                XElement doc = XElement.Parse(@"<magento_api>
                                                  <data_item>
                                                    <code>400</code>
                                                    <message>Attribute weight is not applicable for product type Configurable Product</message>
                                                  </data_item>
                                                  <data_item>
                                                    <code>400</code>
                                                    <message>Resource data pre-validation error.</message>
                                                  </data_item>
                                                  <data_item>
                                                    <code>1</code>
                                                    <message></message>
                                                  </data_item>
                                                  <data_item>
                                                    <code></code>
                                                    <message>No code was given</message>
                                                  </data_item>
                                            </magento_api>");
                Console.Write(doc.ToString());
                Console.WriteLine("");
                Console.WriteLine("----OLD TREE ENDS---");
                Console.WriteLine("");
                doc.Descendants().Where(e => string.IsNullOrEmpty(e.Value)).Remove();
                Console.WriteLine("----NEW TREE STARTS---");
                Console.Write(doc.ToString());
                Console.WriteLine("");
                Console.WriteLine("----NEW TREE ENDS---");
                Console.ReadKey();
            }
        }
    }
