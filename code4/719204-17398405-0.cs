      public String TicketNumText {
        get {
          return txtbox_ticketnum.Text; 
        }
        set {
          txtbox_ticketnum.Text = value; 
        }
      }
    
      ...
    
      con.Open();
    
      try
        {
          MyForm.TicketNumText = com_retrieve.ExecuteScalar().ToString();
           ...
    
      
