     private void CreateEventList()
      {
    
         events = EventDB.ExtractData(); //(mvwDate.SelectionStart);
    
         cboEvent.Items.Clear();
    
         foreach (Event e in events)
         {
            cboEvent.Items.Add(e.GetDisplayText());
         }
    
    
      } //end method CreateEventList
