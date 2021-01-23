    public class ServiceObject{
    
    public String Command {get;set;}
    public String Message {get;set;}
    
      public ServiceObject(String Command,String Message){
       this.Command = Command;
       if(Message!=null)
         this.Message = Message;
    
      }
    
    }
