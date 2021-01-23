            // Use this if you're loading XML from a string
            XDocument doc = XDocument.Parse(inputString);
            // Use this if you're loading XML from a file
            //XDocument doc = XDocument.Load(<filepath>);
            
            var pElements = doc.Root
                .Descendants()
                .Where(el => el.Name.LocalName == "p" && el.Parent.Name.LocalName != "pict");
            List<string> innerTexts = new List<string>();
            foreach(XElement p in pElements)
            {
                var rElements =  p.Elements().Where(el => el.Name.LocalName == "r");
                foreach(XElement r in rElements)
                {
                    var tElements = r.Elements().Where(el => el.Name.LocalName == "t");
                    innerTexts.AddRange(tElements.Select(el => el.Value).ToArray());
                }
            }
