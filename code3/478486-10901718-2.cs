    [ComVisable(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]     
    [Guid("9C674ECA-1B71-42EA-9DB2-9A0EA57EC121")]     
    [Description("Hello Server")]     
    public class HelloServer : ServicedComponent, IHelloServer     
    {         
        [Description("Say Hello!")]         
        public String SayHello()         
        {             
            return "Hello!, ";          
        }     
    }
 
