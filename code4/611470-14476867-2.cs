    public interface IURLInvoke 
    {
        string InvokeURI(Uri myUri);
    }
    
    // some implementation
    public class YourURLInvoker: IURLInvoke 
    {
        public string InvokeURI(Uri myUri)
        {
             // do something
        }
    }
    
    pubic class YourClass 
    {
        public IURLInvoke Invoker {get; set;}
    
        public void InvokeURI(Uri myUri)
        {
             if(Invoker == null)
                  return; 
             
             string xml = Invoker.InvokeURI(Uri myUri);
             // put your code for deserialization here
        }
    }
    
    // here is an usage example:
    YourClass a = new YourClass();
    // set an Invoker
    a.Invoker = new YourURLInvoker();
    a.InvokeURI(url);
