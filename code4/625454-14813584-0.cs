    string[,] TwoDimentionalArray = new string[100, 100];
    for (int i = 0; i < MapLine.Count; i++)
    {
         for (int j = 0; j < MapLine[i].length(); j++)
         {
              TwoDimentionalArray[i, j] = MapLine[i].SubString(j,j);
         }
    }
