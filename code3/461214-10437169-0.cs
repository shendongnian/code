    string[] oEmails = orderEmails.Split(',');
    foreach (string email in oEmails)
    {
        bool index = part[Constants.Emails].IndexOf(email);               
        if (index != -1 && 
            (index == 0 || part[Constants.Emails - 1] == ',') &&
            (index + email.Length == part[Constants.Emails].Length || part[Constants.Emails + 1] == ','))
        {
            part[Constants.Emails] += "," + email;
        }
  }
}
