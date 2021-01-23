    class A 
    { 
    string q; 
    bool hasBeenSet;
    public void SomeMethod () 
    {  
         new Thread(Method ()).Start(); 
         
         while(!hasBeenSet)
         {
           Thread.Sleep(10);
         }
         
         Console.WriteLine (q);   //this writes out nothing 
    } 
    private void Method () 
    {  
         q = "Hello World"; 
         hasBeenSet = true;
    } 
    } 
