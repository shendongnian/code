    [MessageProcessor("TypeB")]
    public class TypeBMessageProcessor : IMessageProcessor
    {
      void IMessageProcessor.Process(byte[] message)
      {
         ....
      }
    }
