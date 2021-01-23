    DateTime birthDate;
    if (DateTime.TryParse(dRow["DATEOFBIRTH"].ToString(), out birthDate))
    {
        // Success case
    }
    else
    {
        // Handle error case
    }
