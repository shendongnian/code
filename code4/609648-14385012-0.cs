    public void SendEmails(String esmails)
    {
        List<String> split = esmails.Split(new String[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Replace(";", "")).ToList();
    Dictionary<Int32, String> dictionary = new Dictionary<Int32, String>();
    foreach (Email email in GetEmails())
    {
        foreach (String address in split)
        {
            if (email.EmailAddress.Equals(address))
                dictionary[email.IdentificationNo] = email.EmailAddress;
        }
  }
