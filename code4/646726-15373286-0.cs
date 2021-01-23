        List<sik> siks = new List<sik>();
        sik input = new sik();
        for (int i = 0; i < 5; i ++)
        {
            input.skId = securitiesArray[i].skId;
            input.country = securitiesArray[i].country;
            
            siks.Add(input);
        }
