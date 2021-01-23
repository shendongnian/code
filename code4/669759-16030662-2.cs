            XDocument doc = XDocument.Load(@"e:\input\partylist.xml");
            var eles = doc.Element("party_list").Elements("party");
            foreach (XElement ele in eles)
            {
                Console.WriteLine (ele.Attribute("currency").Value);
                Console.WriteLine(ele.Attribute("id").Value);
            }
            Console.ReadLine();
