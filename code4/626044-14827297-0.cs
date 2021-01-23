    public DateTime Validate(string dateString)
    {
            DateTime dt;
            if(DateTime.TryParse(dateString, out dt))
                return dt;
            else
                return DateTime.Now; //default value
                          
             
    }
