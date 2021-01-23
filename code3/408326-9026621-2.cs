    using System;
    using System.Web;
    
    class Program
    {
        static void Main()
        {
            var values = HttpUtility.ParseQueryString(string.Empty);
            values["method"] = "createimage";
            values["chart1"] = "https://chart.googleapis.com/chart?chs=250x100&chd=t:60,40&cht=p3&chl=Hello|World";
            Console.WriteLine(values);
            // prints "method=createimage&chart1=https%3a%2f%2fchart.googleapis.com%2fchart%3fchs%3d250x100%26chd%3dt%3a60%2c40%26cht%3dp3%26chl%3dHello%7cWorld"
        }
    }
