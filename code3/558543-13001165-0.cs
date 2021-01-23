    string temp0 = row[10].ToString();
    DateTime?;
    if (string.IsNullOrEmpty(temp0)) 
    {
        temp = null;
    }
    else
    {
        temp = DateTime.Parse(temp0);
    }
