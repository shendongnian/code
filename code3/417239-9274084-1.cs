    // "BirthDate.ToString() = \"16.2.2012 22:00:00\""
    string birthdate = BirthDate.ToString();
    string query = String.Format("{0}  = \"16.2.2012 22:00:00\"", birthdate);
    // "BirthDate.Value.ToString() = \"16.2.2012 22:00:00\""
    string birthdate = BirthDate.Value.ToString();
    string query = String.Format("{0}  = \"16.2.2012 22:00:00\"", birthdate);
    // "BirthDate == null ? 1=1 : (DateTime)BirthDate.ToString() = \"16.2.2012 22:00:00\""
    string birthdate = (DateTime)BirthDate.ToString();
    string query = String.Format("BirthDate == null ? 1=1 : {0} = \"16.2.2012 22:00:00\"", 
                               birthdate);
