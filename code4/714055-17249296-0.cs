    Score s = new Score();
                    foreach (XmlNode child in score.ChildNodes)
                    {
                        if (child.Name == "naam")
                        {
                           s.Naam = child.InnerText;
                        }
                        if (child.Name == "punten")
                        {
                            s.Punten = child.InnerText;
                        } 
                     scores.Add(s); // <-- move here and delete the one under this
                    }
                    scores.Add(s); // <-- see adding s to the List s outside the loop
