    public partial class MyForm {
      ...
      public String TicketNumText {
        get {
          return txtbox_ticketnum.Text; 
        }
        set {
          txtbox_ticketnum.Text = value; 
        }
      }
    
      ...
    
      MyForm form = new MyForm();
    
      ...
    
      con.Open();
    
      try
        {
          form.TicketNumText = com_retrieve.ExecuteScalar().ToString();
           ...
      
