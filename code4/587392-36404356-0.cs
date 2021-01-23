            public static Dictionary<string, dynamic> RecDis(string ThisXML)
        {
            Dictionary<string, dynamic> ThisBlock = new Dictionary<string, dynamic>();
            XElement doc = XElement.Parse(ThisXML);
            XNode[] ThisNoideArray = doc.Nodes().ToArray();
            foreach (XNode park in ThisNoideArray)
            {
                XElement parker = XElement.Parse(park.ToString());
                if (parker.HasElements)
                {
                    ThisBlock.Add(parker.Name.ToString(), RecDis(parker.ToString()));
                }
                else
                {
                    ThisBlock.Add(parker.Name.ToString(), parker.Value.ToString());
                }
            }
            return ThisBlock;
        }
