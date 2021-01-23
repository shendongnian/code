    while (st.Peek() >= 0)
    {
        String report1 = st.ReadLine();
        String[] columns = report1.Split(','); //split columns 
        if(columns.Length < 8)
        {
             //Log something useful, throw an exception, whatever.  
             //You have the option to quitely note that there was a problem and 
             //continue on processing the rest of the file if you want.
             continue;
        }
        //working with columns below
    }
