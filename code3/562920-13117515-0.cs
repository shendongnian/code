    string rawFac1 = Fac1Raw.ToString();
    if (rawFac1.Length == 0 || !char.IsDigit(rawFac1[0]))
    {
        //handle invalid value
    }
    else
    {
        var Fac1 = Int32.Parse(rawFac1[0].ToString());
        //...rest of code
    }
