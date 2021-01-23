    using System.Collections.Generic;
    using System.Linq;
    ...
    
    static readonly Random rand = new Random();
    ...
    List<int> lottoNumbers = new List<int>(6);
    int drawnNumber = -1;
    for (int i = 0; i < lottoNumbers.Count; i++) {
         do
         {
             drawnNumber = rand.Next(1, 50); // generate random number
         }
         while (lottoNumbers.Contains(drawnNumber)) // keep generating random numbers until we get one which hasn't already been drawn
         lottoNumbers[i] = drawnNumber; // set the lotto number 
    }
    // print results
    foreach (var n in lottoNumbers)
        Console.WriteLine(n);
    
