    try
    {
        
        string curr_time= DateTime.Now.ToShortTimeString();
        da=new SqlDataAdapter("select SpeechName from Speeches where SpeechTime<'"+curr_time+"'",conn);
        DataSet ds=new DataSet();
        da.fill(ds);
        for(int i=0;i<ds.Tables[0].Rows.Count;i++)
        string speechName=ds.Tables[0].Rows[i][0].toString();//This will give you last speech within that time.
    
    }
    catch(Exception ex)
    {
    }
