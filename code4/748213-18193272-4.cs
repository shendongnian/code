    protected void CustomersGrid_Updating ( Object source, GridViewUpdateEventArgs e )
    {
    
    bool cancel = true;
    object[] keysNewValues = (object[])Array.CreateInstance(typeof(object), e.NewValues.Count);
    e.NewValues.Keys.CopyTo(keysNewValues, 0);
        
    object[] keysOldValues = (object[])Array.CreateInstance(typeof(object), e.OldValues.Count);
    e.OldValues.Keys.CopyTo(keysOldValues, 0);
    
     for (int i=0; i<keysNewValues.Count(); i++)
        {
         if ((e.NewValues[keysNewValues[i]] != null) && (e.OldValues[keysOldValues[i]] != null))
            { 
     
         if ( !(e.NewValues[keysNewValues[i]].ToString().Equals(e.OldValues[keysOldValues[i]])))
        // set cancel to false since you now have atleast one value which is changed
                            cancel = false;
            }
    if ((e.NewValues[keysNewValues[i]] != null) && (e.OldValues[keysOldValues[i]] == null))
                {
                    cancel = false;
                }
    if ((e.NewValues[keysNewValues[i]] == null) && (e.OldValues[keysOldValues[i]] != null))
                {
                    cancel = false;
                }
         }
    
               
         if (cancel)
          e.Cancel = true;
        
        }
