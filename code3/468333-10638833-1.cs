    private void ReadEmails()
    {
      List<Email> copy;
      lock (emails)
      {
        copy = new List<Email>(this.emails);
      }
      foreach (Email email in copy)
      {
        Print(email);
      }
    }
