          while(reader.Read())
         {
                        RecipeItems GSI = new RecipeItems();
                        GSI.RecipeItem = reader[0].ToString();
                        GSI.Sequence = Convert.ToInt32(reader[1].ToString());
                        GSI.RecipeName = reader[2].ToString();
                        GSI.MaxSequence = Convert.ToInt32(reader[3].ToString());
                        
                        
                        if (dictionary.ContainsKey(GSI.RecipeItem))
                        {
                              dictionary.[GSI.RecipeItem] = GSI.Sequence);
                        }
                        else
                        {    
                            dictionary.Add(GSI.RecipeItem, GSI.Sequence);
                        }
                            
                            
                        
        } 
