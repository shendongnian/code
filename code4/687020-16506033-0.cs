    var i = 0;
    
    var lstOptions = new List<string>();
    
    XDocument xdoc = XDocument.Load("Assets/xml_files/flags.xml");                    
    
            foreach (var item in xdoc.Descendants("item").Elements())
            {
                switch (item.Name.LocalName)
                {
                    case "img":
                        questions.ImageName = item.Attribute("src").Value;
                        break;
                    case "option":           
                        lstOption.add(item.Attribute("value").Value);
                        break;
                    case "desc":
                        questions.Description = item.Value;
                        break;
                }
            } 
           
            questions.OptionA = lstOption[0];
            questions.OptionB = lstOption[1];
            questions.OptionC = lstOption[2];
            questions.OptionD = lstOption[3];
