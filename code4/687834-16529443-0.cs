    foreach (line in input)
    { 
        String s1 = line;
        char[] separators = { '|' };
        String[] values = s1.Split(separators);
        String firstName = values[0];
        String lastName = values[1];
        for (i = 2, i < values.length)
        {
            if (values[i] looks like "ENG101")
            {
               add firstName lastName to "ENG101" student list
            }
            else if (values[i] looks like "MTH303")
            {
               ....
            }
            ....
        }
    }
