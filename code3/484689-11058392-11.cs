    public class MySpecialMailerClass {
      public MySpecialMailerClass() {
        MaxCount = -1;
        CurrentCount = 0;
      }
      public int MaxCount {get;set;}
      public int CurrentCount {get;set;}
      public void Start(){
        //do something to get the MaxCount from the database
        //do something to get the messages
        var messages = mailerDbClass.GetMessagesToBeSent();
        MaxCount = messages.Count;
        
        //send the messages
        foreach(message in messages) {
          SendMessage(message);
          CurrentCount += 1;
        }
      }
    }
