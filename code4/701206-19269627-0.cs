  
    if (OnHappened != null)        
    {  
      try 
      {
        OnHappened(theMessage));
      }
      catch (Exception e)
      {
        Messagebox.Show(e.GetType().Name + " : " +  e.message)
      }
    }
