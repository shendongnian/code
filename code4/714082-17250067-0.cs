    string gettime(DateTime updatedat)
    {
         string toren = "A moment earlier";
         TimeSpan ts = DateTime.Now - updatedat;
         if (ts.TotalSeconds<60)
         {
              toren = ts.TotalSeconds.ToString() + " seconds ago";
         }
         else if (ts.TotalMinutes < 60)
         {
              toren = ts.TotalMinutes.ToString() + " minutes ago";
         }
         else if (ts.TotalHours < 24)
         {
              toren = ts.TotalHours.ToString() + " hours ago";
         }
         else if (ts.TotalDays < 30)
         {
              toren = ts.TotalDays.ToString() + " days ago";
         }
         else 
         {
              double month = ts.TotalDays / 30;
              if (month<13)
              {
                   toren = month.ToString() + " months ago";
              }
              else
              {
                   double year = month / 12;
                   toren = year.ToString() + " years ago";
              }
         }
         return toren;
    }
