          try
            {
                Random randomClass = new Random();
                List<int> collection = new List<int>();
                while (collection.Count <= 100)
                {
                    var temp = randomClass.Next(1, 40);
                    if (!collection.Contains(temp))
                    {
                        collection.Add(temp);
                        int New_Reandom = Convert.ToInt32(temp);
                        
                       
                      
                    }
                }
               
            }
            catch
            {
            }
