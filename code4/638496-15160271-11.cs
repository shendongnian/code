    static void Main(string[] args)
    {
        var dtlist = new[]{
            DateTime.Parse("25-July-1985"),
            DateTime.Parse("31-Dec-1956"),
            DateTime.Parse("21-Feb-1978"),
            DateTime.Parse("18-Mar-2005")
        };
        var now = DateTime.Now;
        var birthdays = from dt in dtlist
                        orderby IsBeforeNow(now, dt), dt.Month, dt.Day
                        select dt;
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
    
