    //Check for duplicates
    bool nameValid = names.SingleOrDefault (d => d.Name == name) == null;
    int count = 1;
    while(!nameValid)
    {
        if( names.SingleOrDefault (d => d.Name == name + count.ToString()) == null )
        {
            name = name + count.ToString();
            nameValid = true;
        }
        else
        {
            count++;
        }
    }
    // name now contains a unique name
