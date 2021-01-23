    while (st.Peek() >= 0)
    {
        //try
        //{
        String report1 = st.ReadLine();
        //   textBox3.Text = report1;
        //  String[] values = File.ReadAllText(@"d:\test.csv").Split(',');
        //    File.Move(@"C:\URAFILES\OUT\NOTIFYPAYMENT\Payments.csv", 
        @"C:\URAFILES\OUTBAK\paid.");
        String[] columns = report1.Split(','); //split columns 
        //     Person p = new Person();
        if(columns.Length < 8)
        {
             //Log something useful, throw an exception, whatever.  
             //Just note that there was a problem and continue on with the rest of the file.
             continue;
        }
       //working with columns below
     }
