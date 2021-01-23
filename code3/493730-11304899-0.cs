    using (SqlCeDataReader rdr = sceCmd.ExecuteReader())
    {
        int i = 0;
        while (rdr.Read())
        { 
            // some other code here
            i++;
        }
        rdr.close();
        if(i==0)
        {
            // something to say if its empty
            Console.WriteLine("No data found.");
        } else {
            // something else to say if its not empty
            Console.WriteLine(i + "data found.");
        }
    }
