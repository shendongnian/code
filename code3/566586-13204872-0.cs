    var customers = new[] {
        new {
            Name = "Fred Flintstone",
            City = "Bedrock"
        },
        new {
            Name = "George Jetson",
            City = "Orbit City"
        }
    };
    string template = "Hello, [NAME] from [CITY]!";
    var re = new Regex(@"\[\w+\]"); // look for all "words" in square brackets
            
    foreach (var customer in customers)
    {
        Trace.WriteLine(
            re.Replace(template, m => {
                // determine the replacement string
                switch (m.Value) // m.Value is the substring that matches the RE.
                {
                    // Handle getting and formatting the properties here
                    case "[NAME]":
                        return customer.Name;
                    case "[CITY]":
                        return customer.City;
                    default:
                        // The "mapping code" is not supported, I just return the 
                        // original substring
                        return m.Value;
                }
            }));
    }
