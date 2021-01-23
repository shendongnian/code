    if (string.IsNullOrEmpty(input))
    {
       return new DateTime?();
    }
    else
    {
       return new DateTime?(DateTime.Parse(input));
    }
