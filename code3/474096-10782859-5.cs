    private static int ClickCount
    {
      get 
       {
         if (Session["clickcount"] == null)
         {         Session["clickcount"] = 0; return 0;      }
         else 
            return (int)Session["clickcount"] ; 
       }
       set
       {
          Session["clickcount"] = value;
       }
    } 
