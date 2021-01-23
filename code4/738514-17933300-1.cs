     public static List<double> GetHoursBetweenDates(List<DateTime> aDates)
     {
         List<double> lst = new List<double>();
         aDates.OrderByDescending(d => d).Aggregate((prev, curr) => { lst.Add(prev.Subtract(curr).TotalHours); return curr; });
         return lst;
     }
