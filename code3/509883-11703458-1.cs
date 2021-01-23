    if (reader.Read())
    {
        var loop = true;
        while (loop)
        {
            //1. Here retrive values you need e.g. var myvar = reader.GetBoolean(0);
            loop = reader.Read();
            if (!loop)
            {
                //You are on the last column. Use values read in 1.
                //Do some exceptions
            }
            else {
                //You are not on the last column.
                //Process values read in 1., e.g. myvar
            }
        }
    }
