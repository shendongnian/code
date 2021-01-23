          List<string> queryBuilder = new List<string>();
         //add the seleted items to items in the list
                foreach (ListItem li in MakeList.Items)
                {
              
                    if (li.Selected)
                    {
                        queryBuilder.Add(li.Value);                 
                        queryBuilder.Add("' OR BV.MakeID = '");
                 
                        //build the list of selected makes for later use
                        selectedMakes.Add(li.Value);
                    }
                }
                    try
                    {
                        //remove the last  ' AND BV.MakeID= '
                        queryBuilder.RemoveAt(queryBuilder.Count-1);
                        
                       //add back the ' and the orderby
                        queryBuilder.Add("'");
                        queryBuilder.Add(" ORDER BY [ModelName]");
                        //build the string
                        foreach(string s in queryBuilder){
                        
                            newQuery+= s;
                        
                        }
                  
                        //debug for visibilty 
                        TESTER.Text =newQuery;
