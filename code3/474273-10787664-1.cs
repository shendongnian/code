You would just reset i and resize the array
    int length = newData.Length; // never computer on each iteration
    for (int i = 0; i < length; i++)
    {
        if (condition)
        {
           //do something with the first line
        }
        else
        {
          // Resize array
          string[] newarr = new string[length - 1 - i];
          /*
           * public static void Copy(
           * 	Array sourceArray,
           * 	int sourceIndex,
           * 	Array destinationArray,
           * 	int destinationIndex,
           * 	int length
           * )
           */
          System.Array.Copy(newData, i, newarr, 0, newarr.Length); // if this doesn't work, try `i+1` or `i-1`
          // Set array
          newData = newarr;
          // Restart loop
          i = 0;
        }
    }
