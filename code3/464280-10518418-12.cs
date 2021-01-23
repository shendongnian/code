    static void Evaluate()
    {
      { 
        int i;
      }
      int i; //<-- error
    }
    static void Evaluate3()
    {
       { 
         int i;
       }
       { 
         int i;
       }
       //fine here - both i's are in different scopes.
    }
