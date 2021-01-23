    XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load("sample.xml");
            XmlNodeList name = xmldoc.GetElementsByTagName("name");
            XmlNodeList price = xmldoc.GetElementsByTagName("price");
            XmlNodeList description = xmldoc.GetElementsByTagName("description");
            XmlNodeList calories = xmldoc.GetElementsByTagName("calories");
            for (int i = 0; i < name.Count; i++)
            {
                Console.WriteLine(name[i].InnerText);
                Console.WriteLine("Price: " + price[i].InnerText);
                Console.WriteLine(description[i].InnerText);
                Console.WriteLine("calories: " + calories[i].InnerText);
            }
            Console.ReadKey();
