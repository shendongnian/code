    abstract class Message
    {
      abstract void Comprehend();
      public static Message Factory(){... code here to return message }
    }
    class BigMessage : Message
    {
      public void Comprehend()
      {
        //do work here
      }
    }
    class SmallMessage : Message
    {
      public void Comprehend()
      {
        //do work here
      }
    class Worker
    {
      public void Start()
      {
        var msg = Message.Factory();
        msg.Comprehend();
      }
