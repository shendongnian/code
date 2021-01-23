        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Xml;
        using System.Xml.Linq;
        
        namespace xmltest
        {
            public class KwData
            {
                public string  KEYWORD { get; set; }
                public List<string> Links { get; set; }
            }
        
            class Program
            {
                static void Main(string[] args)
                {
                    XDocument xml = XDocument.Load("XMLFile1.xml");
        
                    List<KwData> KwDataList = new List<KwData>();
        
                    // Use linq to XML
                    KwDataList = (from kwData in xml.Descendants("KW")
                        select new KwData
                        {
                            KEYWORD = kwData.Element("KWNAME").Value,
                            Links = kwData.Elements("YTLINKS").Elements("YT-LINK").Select( x => x.Value).ToList()
                        }).ToList();
                
                }
            }
    
    }
