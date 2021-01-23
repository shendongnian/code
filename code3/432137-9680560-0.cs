    int result;
    if (int.TryParse("123", out result))
    {
        Debug.WriteLine("Valid integer: " + result);
    }
    else
    {
        Debug.WriteLine("Not a valid integer");
    }
