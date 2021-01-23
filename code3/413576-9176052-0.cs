    if (input.Length >= 1 && input[0].Contains("-s"))
    {
        return 1;
    }
    if (input.Length >= 3)
    { 
        return 2;
    }
    if (input.Length >= 4)
    {
        return 3;
    }
    return 0; //what do you return if none of the conditions are met?
