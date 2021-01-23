    public class Program
    {
        static void Main()
        {
            var str = "8 October";
            DateTime date;
            var formats = new[] { "d MMMM", "d MMM" };
            if (DateTime.TryParseExact(str, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                Console.WriteLine(date);
            }
            else
            {
                Console.WriteLine("The date was not in one of the 2 supported formats 'd MMMM' orr 'd MMM'");
            }
        }
    }
