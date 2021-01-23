    public void Main(string[] args)
    {
       DoMyWork();
    
       Console.WriteLine("You have chosen to end the application, hit enter to say Goodbye...");
       Console.ReadLine();
    }
    
    private void DoMyWork()
    {
       //...
    
       string confirm = Console.ReadLine();
    
       if(confirm.ToLower() == "no")
       {
          return;//no need to continue with this function
       }
    
       //carry on with you logic
       Console.WriteLine("Please type your name");
    
       //...
    } 
