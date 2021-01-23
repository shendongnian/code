    const int iterator = 5;
    const int upperBound = 15;
    
    var possibleValues = new List<int>();
    
    for (int i = 0; i <= upperBound; i++)
    {
        if (i % iterator == 0)
        {
        	possibleValues.Add(i);
        }
    }
    
    Random r = new Random();
    var a = possibleValues[r.Next(possibleValues.Count)];
