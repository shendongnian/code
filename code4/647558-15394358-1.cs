    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace XLinqAttributeGetNames
    {
        class Program
        {
            static void Main(string[] args)
            {
                XElement testmultilist = XElement.Parse(@"<rowset>
                    <row attribute1=""somevalue1"" attribute2=""somevalue2"" attribute3=""somevalue3"" attribute4=""somevalue4""/>
                    <row attribute1=""somevalue1"" attribute2=""somevalue2"" attribute3=""somevalue3"" attribute4=""somevalue4""/>
                    <row attribute1=""somevalue1"" attribute2=""somevalue2"" attribute3=""somevalue3"" attribute4=""somevalue4""/>
                    <row attribute1=""somevalue1"" attribute2=""somevalue2"" attribute3=""somevalue3"" attribute4=""somevalue4""/>
                    </rowset>");
    
                var skillslist = testmultilist.Elements("row")
                    .Select(s => s.Attributes()
                        .Select(a => a.Value)
                        .ToList()
                    )
                    .ToList();
    
                for (var i = 0; i < skillslist.Count; i++)
                {
                    Console.WriteLine("Row " + i);
                    for (var j = 0; j < skillslist[i].Count(); j++)
                    {
                        Console.WriteLine("Item " + j + ": " + skillslist[i][j]);
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();
    
            }
        }
    }
