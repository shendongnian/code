     List<int> possibleValues = new List<int>();
     for (int i = 0; i < 64; i++)
     {
         possibleValues[i] = i;
     }
    List<int> result = new List<int>();
    Random r = new Random();
    int numberOfMines = 50; //say you want to put 50 mines there
    for (int i = 0; i < numberOfMines; i++)
    {
        int indice = r.Next(possibleValues.Count);
        int value = possibleValues[indice];
        possibleValues.Remove(value);
        result.Add(value);
    }
