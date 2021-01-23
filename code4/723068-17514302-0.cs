            string pathToXML = "";
            XDocument doc = XDocument.Load(pathToXML);
            var qry = from ele in doc.Descendants("row")
                         select new
                         {
                             name = ele.Attribute("name").Value,
                             charID = Convert.ToInt32(ele.Attribute("characterID").Value),
                             corName = ele.Attribute("corporationName").Value,
                             corID =  Convert.ToInt32(ele.Attribute("corporationID").Value)
                         };
            foreach (var element in qry)
            {
                Console.WriteLine(element.name + " " + element.charID + " " + element.corName + " " + element.corID);
            }
