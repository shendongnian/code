             try{
        SPListItemCollection Items = RiskAssesment.GetItems(new SPQuery() 
                            { 
                                Query = @"<Where> 
                                                 <Eq> 
                                                    <FieldRef Name='Department'/> 
                                                    <Value Type='Text'>"+Department+"</Value>                           </Eq></Where>" 
                            }); 
                             if(Items != null){
                            foreach (SPListItem item in Items) 
                            { 
                                if (item != null) 
                                { 
                                    item["Name"]="abcd"; 
                                    item.Update(); 
                                } 
                                else 
                                { 
                                    newListItem["Name"] = "xyz"; 
                                    newListItem.Update(); 
                                } 
                            } 
    
                        }
                                
            }
            Catch(Exception exc){
            //Do something with your exception here
            }
