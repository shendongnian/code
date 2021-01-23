    class Program
     {
     static void Main(string[] args)
     {
     IKernel _Kernal = new StandardKernel();
     _Kernal.Load(Assembly.GetExecutingAssembly());
     ISMSService _SMSService = _Kernal.Get<ISMSService>();
    
    UIHandler _UIHandler = new UIHandler(_SMSService);
     _UIHandler.SendConfirmationMsg("96279544480");
    
    Console.ReadLine();
     }
     }
  
