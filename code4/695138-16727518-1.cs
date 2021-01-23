    static DataTable dt;
    static DateTime LastPulled;
    public static void GetData()
        {
        if(LastPulled==null || DateTime.Now-LastPulled > new TimeSpan(5))
            {
            //Retrieve DataTable from database
            }
         return dt;
        }
