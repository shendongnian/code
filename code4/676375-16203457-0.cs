    int Size = OldArray.Length;
    int[,] NewPoints = null;
    
    if (Size % 2 != 0) {
      //Error - Array has odd number of elements!
    } else {
      for (i = 0; i <= Size - 1; i += 2) {
        Array.Resize(ref AllPoints, (i / 2) + 1, 2);
        NewPoints[i / 2, 0] = OldArray(i);
        NewPoints[i / 2, 1] = OldArray(i + 1);
      }
    }
