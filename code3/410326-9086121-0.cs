    using System;
    using System.Xml.Linq;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var doc = XDocument.Parse(@"<root>
     <werk>
      <titel>So What?</titel>
      <gattung>Pop</gattung>
      <interpret>Pink</interpret>
      <komponist>Max Martin</komponist>
      <entstehungsjahr>2008</entstehungsjahr>
     </werk>
    </root>");
                var elementsAfterTitel = doc.Element("root").Element("werk").Element("titel").ElementsAfterSelf();
                foreach (var element in elementsAfterTitel)
                {
                    Console.WriteLine(element.ToString());
                }
                Console.ReadLine();
            }
        }
    }
