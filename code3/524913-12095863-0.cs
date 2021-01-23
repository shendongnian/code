    string[] parts = tString.Split('-'); 
    if (parts.Length == 2)
    {
        flLeg = parts[1]; 
        if (int.TryParse(parts[0], out flNum )
        {
            //All good
        }
        else
        {
            //Handle problem
        }
    }
    else
    {
       //Handle problem
    }
