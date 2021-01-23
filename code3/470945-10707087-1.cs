    // class where you know something
    class A
    {
       //delegate for answer
       public Func<bool> AskForSomething { get; set; }
    
       public void DoSomething()
       {
          //some code
          if(AskForSomething())
          {
              //do something
          }
          else
          {
              //do something else
          }
       }
    }
    
    class B
    {
       public void Test()
       {
          A a = new A();
          a.AskForSomething = new Func<bool>(Answer);
          a.DoSomething();
       }
    
       private bool Answer()
       {
           return true;
       } 
    }
