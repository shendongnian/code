    private Control FindALL(ControlCollection page, string id)
    {
      foreach (Control c in page)
      {
        if (c.ID == id)
          return c;
        if (c.HasControls())
        {
          var res = FindALL(c.Controls, id);
		  if (res != null) 
            return res;
        }	  
      }
      return null;
    }
