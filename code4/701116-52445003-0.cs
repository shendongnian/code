    XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load("TheXMLFile.xml");
    
                Console.WriteLine($"Contact: {xmldoc.DocumentElement.SelectNodes("Contact").Count}"); // return 2
                Console.WriteLine($"/Contact: {xmldoc.DocumentElement.SelectNodes("/Contact").Count}"); // return 0, and it is the expected!
                Console.WriteLine($"//Contact: {xmldoc.DocumentElement.SelectNodes("//Contact").Count}"); // return 2
    
                foreach (XmlNode firstName in xmldoc.DocumentElement.SelectNodes("//Profiles/Personal/FirstName"))
                {
                    Console.WriteLine($"firstName {firstName.InnerText}");
                }
