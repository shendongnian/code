       string[] firstNames = {"Mark", "Mike" };
       string[] lastNames = {"Watson", "Wilson" };
       IList<string> allNameCombinations = new List<string>();
        
       foreach (string firstname in firstNames)
       {
           foreach (string lastname in lastNames)
           {
                allNameCombinations.Add(firstname + " " + lastname);
            }
        }
        
       string[] allNames = allNameCombinations.ToArray();
