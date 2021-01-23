     public static List<double> GetHoursBetweenDates(List<DateTime> aDates)
     {
         List<double> lst = new List<double>();
         aDates.OrderByDescending(d => d).Aggregate((x, y) => { lst.Add(x.Subtract(y).TotalHours); return y; });
         return lst;
     }
