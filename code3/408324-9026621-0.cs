    using System;
    using System.Web;
    
    class Program
    {
        static void Main()
        {
            var query = "?method=createimage&chart1=https://chart.googleapis.com/chart?chs=250x100&chd=t:60,40&cht=p3&chl=Hello|World";
            var values = HttpUtility.ParseQueryString(query);
            Console.WriteLine(values["method"]);
            Console.WriteLine(values["chart1"]);
        }
    }
