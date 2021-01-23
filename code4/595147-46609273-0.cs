    if(obj.myDate == DateTime.MinValue)
    {
        aCommand.Parameters.Add("dateParameter", SqlDbType.Date).Value = DBNull.Value;
    }
    else
    {
        aCommand.Parameters.Add("dateParameter", SqlDbType.Date).Value = obj.myDate ;
    }
