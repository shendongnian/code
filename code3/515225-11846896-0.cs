     List<delegateinfo> propList = new List<delegateinfo>();
                var list = document.Descendants().ElementAt(1);
                foreach (var tempVar in list.Descendants())
                {
                    delegateinfo obj = new delegateinfo();
                    foreach (var delegateinfo_ in tempVar.Descendants())
                    {
                        MessageBox.Show(delegateinfo_.Attribute("value").Value);
                        if (delegateinfo_.Attribute("label").Value.CompareTo("fname") == 1)
                            obj.firstName = delegateinfo_.Attribute("value").Value;
                        else
                            if (delegateinfo_.Attribute("label").Value.CompareTo("lname") == 1)
                                obj.lastName = delegateinfo_.Attribute("value").Value;
                        else
                                if (delegateinfo_.Attribute("label").Value.CompareTo("ccountry") == 1)
                                    obj.country = delegateinfo_.Attribute("value").Value;
                        else
                                    if (delegateinfo_.Attribute("label").Value.CompareTo("industry") == 1)
                                        obj.industry = delegateinfo_.Attribute("value").Value;
                        propList.Add(obj);
                
                      
                    }
                  
                   
                }
