    public class MyClass
    {
      public Progress MyProgress { get; set; }
    
      public MyClass()
      {
        MyProgress = new Progress();
      }
    
      public void Run()
      {    
        MyProgress.Status = "Initialising";
        // Do stuff, update progress, etc.
      }
    }
