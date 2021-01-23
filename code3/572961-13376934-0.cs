    // sample input
    var inputs = new string[] { "08.11.12", "08.11", "08-11", "08-11-12" };
    // possible formats
    var formats = new string[] { "dd-MM-yyyy", "dd.MM.yyyy" };
    // try to parse all your sample data
    for (int i = 0; i < inputs.Length; i++)
    {
        string input = inputs[i];
        var tokens = input.Split(new[] { '-', '.' }, StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 2)
        {
            input = string.Format("{0}-{1}"
                    , input
                    , DateTime.Today.Year);
        }
        else if (tokens.Length == 3)
        {
            string year = tokens[2];
            if (year.Length != 4)
            { 
                year = string.Format("{0:20##}", int.Parse(year));
            }
            input = string.Format("{0}-{1}-{2}"
                    , tokens[0]
                    , tokens[1]
                    , year);
        }
        else
            throw new ArgumentException("Invalid DateTime", "filter.SearchingValue");
        DateTime dt = DateTime.MinValue;
        foreach (string format in formats)
        {
            bool success = DateTime.TryParseExact(
                input
                , format
                , CultureInfo.InvariantCulture
                , DateTimeStyles.None
                , out dt);
            if (success) break;
        }
        Console.WriteLine(dt.ToString());
    }
