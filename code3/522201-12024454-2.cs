    string temp;
    while ((line = sr.ReadLine()) != null)
                    {
    
                        if (line.Contains(searchkey))
                        {
                           temp = line;
                           break;
                         }
                    }
    
