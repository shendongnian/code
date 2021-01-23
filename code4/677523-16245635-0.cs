    DateTime dateTime;
    string dateString = ds.Tables[0].Rows[0]["Dt"].ToString();
    bool result = DateTime.TryParse(dateString , out dateTime);
    if(result)
    {
         // Use `dateTime` variable then
    }
