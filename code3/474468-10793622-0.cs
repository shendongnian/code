        string[,] a = new string[,]
                        {
                            {"ant", "AUNT_ID"},
                            {"Sam", "AUNT_NAME"},
                            {"clozapine", "OPTION"},
                        };
        string search = "ant";
        string result = String.Empty;
        for (int i = 0; i < a.GetLength(0); i++) //loop until the row limit
        {
            if (a[i, 0] == search)
            {
                result = a[i, 1];
                break; //break the loop on find 
            }
            
        }
        Console.WriteLine(result); // this will display AUNT_ID
