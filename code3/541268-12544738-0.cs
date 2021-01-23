    public class ConnectionCheck
    {
      private Form myForm;
    
       public void   ConnectionCheck(Form form)
      {
        myForm = form;
      }
    
      public bool openConnection()
      {
        SetStatus("Connecting to " + Server);       
        //Mysql code
      }
    
      private void SetStatus(string msg)
      {
         //Call method to change label text
          myForm .SetStatus(msg);
      }
    
    }
