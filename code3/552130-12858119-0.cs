                           SPListItemCollection Items = RiskAssesment.GetItems(new SPQuery()
                            {
                                Query = @"<Where>
                                             <Eq>
                                                <FieldRef Name='Department'/>
                                                <Value Type='Text'>" + Department + "</Value></Eq></Where>"
                            });
                            if (Items.Count==0)
                            {
                               item["Name"]="abcd"; 
                                item.Update(); 
                            }
                            else
                            {
                                foreach (SPListItem item in Items)
                                {
                                    if (item != null)
                                    {
                                       item["Name"]="abcd"; 
                                item.Update(); 
                                    }
                                }
                            }
