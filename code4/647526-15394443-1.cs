    string s = "5";
    double d;
    if (Double.TryParse(s, out d)) {
        Console.WriteLine("OK. Result = {0}", d);
    } else {
        Console.WriteLine("oops!");
    }
