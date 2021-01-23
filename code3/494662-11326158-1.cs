    List<DateTime> dateList = 
      nameList.Select(x =>
      DateTime.ParseExact(
                          x.TrimEnd("PM".ToCharArray()).TrimEnd("AM".ToCharArray()), 
                         "yyyyMMdd", 
                          CultureInfo.InvariantCulture)
                          ).ToList();
                var Minimum = dateList.Min();
                var Maximum = dateList.Max();
                Console.WriteLine(Minimum.ToString());
                Console.WriteLine(Maximum.ToString());
