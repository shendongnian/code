    var input = new string []{ "16-Oct-12 7:25:22 PM",
                    "16/10/2012 7:10:47 PM",
                    "10/16/2012 7:10:51 PM"};
    foreach (var date in input)
    {
        var result = DateTime.MinValue;
        if (DateTime.TryParse(date, out result))
        {
            Console.WriteLine("Date value: {0}", result);
        }
        else
        {
            Console.WriteLine("Cannot parse value {0}", date);
        }
    }
