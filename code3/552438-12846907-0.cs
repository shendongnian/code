    var arr = new[,]
                              {
                                  {"expensive", "costly", "pricy", "0"},
                                  {"black", "dark", "0", "0"}
                              };
                int line = 0;
                int positionInLine = 3;
                string newValue = "NewItem";
    
    
                for(var i = 0; i<=line;i++)
                {
                    for (int j = 0; j <=positionInLine; j++)
                    {
                        if (i == line && positionInLine == j)
                        {
                            var tmp1 = arr[line, positionInLine];
                            arr[line, positionInLine] = newValue;
    
                            try
                            {
                                // Move other elements
                                for (int rep = j+1; rep < int.MaxValue; rep++)
                                {
                                    var tmp2 = arr[line, rep];
    
                                    arr[line, rep] = tmp1;
    
                                    tmp1 = tmp2;
    
                                }
                            }
                            catch (Exception)
                            {
                                
                                break;
                            }
                        }
                    }
                }
