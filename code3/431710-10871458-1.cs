    private object LastTab = null;
    
    private void tabSelectionChanged(...)
    {
      if(LastTab != null)
      {
         //Do save
      }
    
      LastTab = control.SelectedContent;
    }
    
