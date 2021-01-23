    public static List<Tuple<string,string>> ReadLogFile(List<string> fileNames)
    {
       ...
       var items = new List<Tuple<string,string>>();
       foreach (var minDate in minDates)
       {
          var item = new Tuple<string, string>(minDate.ToString(), String.Format("{0} - {1}", minDate, minDate.AddMinutes(30));
          items.Add(item);
       }
       return items;
    }
