    DateTime dtmEndDate;
    if (DateTime.TryParse(dtCommunication.Rows[0]["DateEnd"].ToString(), out dtmEndDate))
    {
       // okey dokey
    }
    else
    {
       throw new SomeException(String.Format("{0} is not a valid date",dtCommunication.Rows[0]["DateEnd"].ToString());
    }
