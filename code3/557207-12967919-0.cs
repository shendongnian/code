    using System.Diagnostics;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace ConsoleApplication6
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string frag = @" <websites>
     <site>
     <a xmlns=""http://www.w3.org/1999/xhtml"" href=""www.google.com""> Google </a>
     </site>
     <site>
     <a xmlns=""http://www.w3.org/1999/xhtml"" href=""www.hotmail.com""> Hotmail </a>
     </site>
     </websites>";
    
                var doc = XDocument.Parse(frag);
    
                //Locate all the elements that contain the attribute you're looking for
                var invalidEntries = doc.Document.Descendants().Where(x =>
                {
                    //Get the href attribute from the element
                    var hrefAttribute = x.Attribute("href");
                    //Check to see if the attribute existed, and, if it did, if it has the value you're looking for
                    return hrefAttribute != null && hrefAttribute.Value.Contains("www.google.com");
                });
    
                //Find the site elements that are the parents of the elements that contain bad entries
                var toRemove = invalidEntries.Select(x => x.Ancestors("site").First()).ToList();
    
                //For each of the site elements that should be removed, remove them
                foreach(var entry in toRemove)
                {
                    entry.Remove();
                }
    
                Debugger.Break();
            }
        }
    }
