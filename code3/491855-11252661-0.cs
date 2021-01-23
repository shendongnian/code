    int value;
    bool success = int.TryParse(value);
    if (success)
    {
        //... all is well, use value
    }
    else
    {
        // Show an error message that the user must enter an integer.
    }
