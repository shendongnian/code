    string x = "1234";
    double y;
    if(double.TryParse(x, out y))
    {
        Console.WriteLine("success y = " + y.ToString());
    }
    else
    {
        Console.WriteLine(x + " could not be converted to a double");
    }
