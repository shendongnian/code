      [ProtoContract]
      public abstract class Message
      {
        public byte[] Serialize()
        {
          byte[] result;
          using (var stream = new MemoryStream())
          {
            Serializer.Serialize(stream, this);
            result = stream.ToArray(); //GetBuffer was giving me a Protobuf.ProtoException of "Invalid field in source data: 0" when deserializing
          }
          return result;
        }
      }
    
      [ProtoContract]
      public class Message<T> : Message
      {
        [ProtoMember(1)]
        public string From { get; private set; }
        [ProtoMember(2)]
        public string To { get; private set; }
        [ProtoMember(3)]
        public T MessageBody { get; private set; }
    
        public Message()
        { }
    
        public Message(string from, string to, T messageBody)
        {
          this.From = from;
          this.To = to;
          this.MessageBody = messageBody;
        }
        
        public static Message<T> Deserialize(byte[] message)
        {
          Message<T> result;
          using (var stream = new MemoryStream(message))
          {
            result = Serializer.Deserialize<Message<T>>(stream);
          }
          return result;
        }
      }
