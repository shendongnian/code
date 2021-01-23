    var subjects = from subjectElement in xml.Descendants("Subject")
                   select new QuestionnnaireSubject()
                   {                                         
                       Description = (string)subjectElement.Attribute("Desc")
                       ID = (int)subjectElement.Attribute("ID").Value
                   }; 
