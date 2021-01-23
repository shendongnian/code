     Use the below code:
    
    private object LastTab = null;
    
    private void tabSelectionChanged(...)
    {
      if(LastTab != null)
         //Do save
    
      LastTab = control.SelectedContent;
    }
    
    Here the the content will be of type object you can type cast to specific class and do the save operation
