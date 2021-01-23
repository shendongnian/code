    Interface IAClass
    {
      void Add(string s);
    }
    Interface IBClass
    {
      void Delete(string m);
    }
    
    
    Class A: IAClass
    {
      void Add(string name)
    {
      // Your Logic
    }
    }
    
    Class B: IBClass
    {
      void Delete(string name)
    {
      // Your Logic
    }
    }
    
    Class C:IAClass,IBClass
    {
         void Add(string name)
    {
      // Your Logic
    }
    
     void Delete(string name)
    {
      // Your Logic
    }
    }
