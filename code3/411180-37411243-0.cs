    //greater than or equal to zero floating point numbers
    Regex floating = new Regex(@"^[0-9]*(?:\.[0-9]+)?$");
            Dictionary<string, bool> test_cases = new Dictionary<string, bool>();
            test_cases.Add("a", floating.IsMatch("a"));
            test_cases.Add("a.3", floating.IsMatch("a.3"));
            test_cases.Add("0", floating.IsMatch("0"));
            test_cases.Add("-0", floating.IsMatch("-0"));
            test_cases.Add("-1", floating.IsMatch("-1"));
            test_cases.Add("0.1", floating.IsMatch("0.1"));
            test_cases.Add("0.ab", floating.IsMatch("0.ab"));
            test_cases.Add("12", floating.IsMatch("12"));
            test_cases.Add(".3", floating.IsMatch(".3"));
            test_cases.Add("12.3", floating.IsMatch("12.3"));
            test_cases.Add("12.3.4", floating.IsMatch("12.3.4"));
            test_cases.Add(".", floating.IsMatch("."));
            
            test_cases.Add("0.3", floating.IsMatch("0.3"));
            test_cases.Add("12.31252563", floating.IsMatch("12.31252563"));
            test_cases.Add("-12.31252563", floating.IsMatch("-12.31252563"));
            foreach (KeyValuePair<string, bool> pair in test_cases)
            {
                Console.WriteLine(pair.Key.ToString() + "  -  " + pair.Value);
            }
