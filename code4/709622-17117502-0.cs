      private bool isAlphabetic(string toCheck)
      {
         toCheck = toCheck.ToLower();
         for (int i = 0; i < toCheck.Length; i++)
         {
            if (i+1 < toCheck.Length && toCheck[i] > toCheck[i + 1])
               return false;
         }
         return true;
      }
