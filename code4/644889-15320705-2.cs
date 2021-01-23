    public void SetNewState (GameEvents newEvent) 
      {
         //Save new state to some Property
         //...
    
         //and notify everybody about new state
         if(StateChanged != null)
         {
            StateChanged(newEvent);
         }
       }
