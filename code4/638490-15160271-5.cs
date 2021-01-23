    static void Main(string[] args)
    {
        var dtlist  = new[]{
            DateTime.Parse("25-July-1985"),
            DateTime.Parse("31-Dec-1956"),
            DateTime.Parse("21-Feb-1978"),
            DateTime.Parse("18-Mar-2005")
        };
        var ordered = (from dt in dtlist
                      orderby dt.Month, dt.Day
                      select dt)
                      .ToArray();
        var now = DateTime.Now;
        var afterNow = ordered.SkipWhile(dt => IsBeforeNow(now, dt));
        var beforeNow = ordered.TakeWhile(dt => IsBeforeNow(now, dt));
        var birthdays = Enumerable.Concat(afterNow, beforeNow);
        foreach (var dt in birthdays)
        {
            Console.WriteLine(dt.ToString("dd-MMM"));
        }
        Console.ReadLine();
    }
    private static bool IsBeforeNow(DateTime now, DateTime dateTime)
    {
        return dateTime.Month < now.Month
            || (dateTime.Month == now.Month && dateTime.Day < now.Day);
    }
    
