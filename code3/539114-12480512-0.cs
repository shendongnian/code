    for (int i = 1; i <= 36; i++)
    {
        if (i.ToString().Length == 1)
        {
               Response.Write(i.ToString().PadLeft(2,'0'));
        }
    }
