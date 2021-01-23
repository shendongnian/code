    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Net;
    using System.Runtime.Serialization.Json;
    using System.Xml;
    namespace ConsoleApplication1
    {
        class Program
        {
            static dynamic RecursiveBuildUp (XmlReader reader)
            {
                object result = null;
                while (reader.Read ())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            // TODO: It seems array elements are identified with the an "item" key
                            // This can create problems if the json object has a property name "item"
                            if (reader.LocalName == "item")
                            {
                                var list = result as List<object>;
                                if (list == null)
                                {
                                    list = new List<object>();
                                    result = list;
                                }
                                list.Add (RecursiveBuildUp (reader));
                            }
                            else
                            {
                                var dic = result as IDictionary<string, object>;
                                if (dic == null)
                                {
                                    dic = new ExpandoObject ();
                                    result = dic;
                                }
                                var localName = reader.LocalName;
                                dic[localName] = RecursiveBuildUp (reader);
                            }
                            break;
                        case XmlNodeType.Text:
                            result = reader.Value;
                            break;
                        case XmlNodeType.EndElement:
                            return result;
                        default:
                            throw new Exception ("Unhandled node type: " + reader.NodeType);
                    }
                }
                return result;
            }
            static void Main (string[] args)
            {
                var wc = new WebClient ();
                var json = wc.DownloadData ("https://raw.github.com/currencybot/open-exchange-rates/master/latest.json");
                
                var quotas = new XmlDictionaryReaderQuotas ();
                var reader = JsonReaderWriterFactory.CreateJsonReader (json, quotas);
                var result = RecursiveBuildUp (reader);
                Console.WriteLine (result.root.rates.AED);
            }
        }
    }
