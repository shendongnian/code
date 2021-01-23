        using System.Xml.Linq;
        public static class Xml
        {
            /// <summary>
            /// Recursive method to shorten all xml end tags starting from a given element, and running through all sub elements 
            /// </summary>
            /// <param name="elem">Starting point element</param>
            public static void ToShortEndTags(this XElement elem)
            {
                if (elem == null) return;
    
                if (elem.HasElements)
                {
                    foreach (var item in elem.Elements()) ToShortEndTags(item);
                    return;
                }
    
                var reduced = Regex.Replace(elem.ToString(), ">[\\s\\n\\r]*</\\w+>", "/>");
                elem.ReplaceWith(XElement.Parse(reduced));
            }
        }
