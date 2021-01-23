    IEnumerable<int> GetLessThanThree(IEnumerable<int> list)
    {
       List<int> result = new List<int>();
       foreach(int num in list)
       {
         if (num < 3)
         {
            result.Add(num);
         }
       }
       return result;
    }
