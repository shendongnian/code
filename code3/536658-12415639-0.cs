    static void Main(string[] args)
    {    
         var listTimes = new string[] {"09.00 AM", "12.00 PM", "03.00 AM"};
         const string testTimeValue = "02.00 PM";
         Console.WriteLine(CompareFunction(listTimes, testTimeValue));
    }
    
    
    public static string CompareFunction(IEnumerable<string> listTimes, string testTimeValue)
    {
         double minDiff = double.MaxValue;
         string result = string.Empty;
    
         foreach(string listTime in listTimes)
         {
              double difference = GetDifference(listTime, testTimeValue);
              if(difference < minDiff)
              {
                    minDiff = difference;
                    result = listTime;
              }
         }
         return result;
    }
    
    private static double GetDifference(string time1, string time2)
    {
         return Math.Abs(ConvertStringTime(time1).TotalMinutes - ConvertStringTime(time2).TotalMinutes);
    }
    
    private static TimeSpan ConvertStringTime(string time)
    {
         Regex validationRegex = new Regex(@"\d\d.\d\d AM|PM");
         if(!validationRegex.IsMatch(time)) throw new FormatException("Input time string was not in correct format");
    
         Regex hoursRegex = new Regex(@"\d\d.");
         Regex minutesRegex = new Regex(@".\d\d");
         bool postMeridiem = time.Contains("PM");
    
         string hstring = hoursRegex.Match(time).ToString().Replace(".", string.Empty);
         string mstring = minutesRegex.Match(time).ToString().Replace(".", string.Empty);
    
         double h = postMeridiem ? double.Parse(hstring) + 12 : double.Parse(hstring);
         double m = double.Parse(mstring);
    
         return new TimeSpan(0, (int)h, (int)m, 0);
    }
