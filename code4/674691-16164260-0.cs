    string Input = "xyz";
    string Output = string.Empty;
    
    if (Input.StartsWith("x"))
    {
        Output = "string starts with an X";
    }
    else if (Input.Contains("y"))
    {
        Output = "string has a 'y' in it";
    }
    else if (Input.IndexOf("z") == 2)
    {
        Output = "string has a 'z' as the 3rd character";
    }
    else
    {
        Output = "string does not match any conditions";
    }
