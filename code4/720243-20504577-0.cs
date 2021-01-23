    var allNumbers = Enumerable.Range(0, 999999); //999999 is arbitrary. You could use int.MaxValue, but it would degrade performance
    var existingNumbers = new int[] { 0, 1, 2, 4, 5, 6 };
        
    int result;
    var missingNumbers = allNumbers.Except(existingNumbers);
    if (missingNumbers.Any())
      result = missingNumbers.First();
    else //no missing numbers -- you've reached the max
      result = -1;
