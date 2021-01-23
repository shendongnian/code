    IEnumerable<int> GetLessThanThree(IEnumerable<int> list)
    {
       foreach(int num in list)
       {
         if (num < 3)
         {
            yield return num
         }
       }
    }
