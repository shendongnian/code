    class CustomEventHandler1 : EventArgs
    {
       public CustomEventHandler1(string u, string d)
       {
          msgu = u;
          msgd = d;
       }
       private string msgu;
       private string msgd;
       public string Username
       {
         get { return msgu; }
       }
       public string Directory
       { 
         get { return msgd; }
       }
    }
