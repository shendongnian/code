    static class User
    {        
        public string set_name;
       
        public static string name
        {
          get
          {
            return this.set_name;
          }
          set 
          {
            this.set_name = value;
          }
    }
