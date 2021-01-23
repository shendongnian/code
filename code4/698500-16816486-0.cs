    var query = from invite in db.invites
            where invite.Division.Matches(userInput.Division.Text) &&
                  invite.Status.Matches(userInput.Status.Text)
            select invite;
-----
    static class Extensions
    {
        public static bool Matches(this string text, string value)
        {
          if(string.IsNullOrEmpty(value)) return true;
          return text == value; // or same safer comparison
        }
    }
