    Object[,] myObjects = new Object[3, 2] { { 1, 2 }, { 3, 4 },
                                            { 5, 6 } };
    
    string[,] myString = new string[3, 2];
    
    for (int i = myObjects.GetLowerBound(0); i < myObjects.GetUpperBound(0); i++)
    {
         for (int j = myObjects.GetLowerBound(1); j < myObjects.GetUpperBound(1); j++)
         {
              myString[i, j] = myObjects[i, j].ToString();
         }
    }
    
    foreach (var item in myString)
    {
        Console.WriteLine("{0} - {1}", item.GetType(), item);
    }
