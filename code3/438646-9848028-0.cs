    public interface IMessage
    {
        void HandleMessage();
    }
    public class DummyMessage : IMessage
    {
         public void HandleMessage()
         {
             Blah;
         }
    }
    public class SillyMessage : IMessage
    {
         public void HandleMessage()
         {
             Yak;
         }
    }
