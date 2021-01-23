    if (OnHappened != null)        
    {  
      try 
      {
        Invoke(OnHappened, theMessage);
      }
      catch (Exception e)
      {
        Messagebox.Show(e.GetType().Name + " : " +  e.message)
      }
    }
