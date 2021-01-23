    public System.Data.DataTable GetProfileSettings(string profilename)
    {
       string sql = "Select Controls_Key+'='+Controls_Value AS Settings From Profile_Controls Where Profile_Name = '"+profilename+"'";
       //write ADO.Net code here to get settings into DataTable
       //DataTable dt = blah blah blah;
    
       return dt;
    }
