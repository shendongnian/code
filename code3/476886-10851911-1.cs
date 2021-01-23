    // your code, char[,] replaced by string[,]
    string[,] table2x2 = new string[2, 2];  
    string myString = "11A23A4A5A"; 
    string[] splitA = myString.Split(new char[] { 'A' }); 
    // this converts splitA into a 2D array
    // Math.Min is used to avoid filling past the array bounds
    for (int i = 0; i < Math.Min(splitA.Length, 2*2); i++) {
        table2x2[i / 2, i % 2] = splitA[i];
    }
