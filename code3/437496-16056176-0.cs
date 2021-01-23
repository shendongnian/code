    int i = User.Emails.Count - 1;
    while (true)
    {
      if (i<0)
      {
         break;
      }
      Db.Emails.DeleteObject(User.Emails.ElementAt<Email>(i));
      i--;
    }
