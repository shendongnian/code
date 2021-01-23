    static IEnumerable<Tuple<int, int>> GetRanges(IEnumerable<int> source)
    {
       bool started = false;
       int rangeStart = 0, lastItem = 0;
       
       foreach (int item in source)
       {
          if (!started)
          {
             rangeStart = lastItem = item;
             started = true;
          }
          else if (item == lastItem + 1)
          {
             lastItem = item;
          }
          else
          {
             yield return new Tuple<int, int>(rangeStart, lastItem);
             rangeStart = lastItem = item;
          }
       }
       
       if (started)
       {
          yield return new Tuple<int, int>(rangeStart, lastItem);
       }
    }
    
    static string FormatRange(Tuple<int, int> range)
    {
       string format = (range.Item1 == range.Item2) ? "{0:D}" : "{0:D}-{1:D}";
       return string.Format(format, range.Item1, range.Item2);
    }
    
    string pageNos = "5,6,7,9,10,11,12,15,16";
    int[] pageNumbers = Array.ConvertAll(pageNos.Split(','), Convert.ToInt32);
    string result = string.Join(",", GetRanges(pageNumbers).Select(FormatRange));
