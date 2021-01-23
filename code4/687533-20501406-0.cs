     public string FormatPostingDate(string txtdate)
     {
         if (txtdate != null && txtdate != string.Empty)
         {
             DateTime postingDate = Convert.ToDateTime(txtdate);
             return string.Format("{0:mm/dd/yyyy}", postingDate);
         }
         return string.Empty;
     }
