    public class Message{
      public int Prefix {get; private set;}
      public byte[] RawPayload {get;private set;}
    
      public PayloadType GetPayload(){
        PayloadType result = null;
        switch (Prefix){ // you can also convert that to int
          case 1:
            result = PayloadType.FromRaw<ForwardMessage>(RawPayload);
            break;
          default:
            break;
        }
      }
    
      public static Message FromStream(Stream s){
        Prefix = ReadTwoBytes(s);
        RawPayload = ReadToEnd(s);
      }
    }
    
    public abstract class PayloadType{
      public int MessageType {get;set;} // enum goes better here
      public abstract SomePayloadMethods();
    
      public static T FromRaw(byte[] raw) where T: PayloadType{
        // deserialize this as you wish
        // such as:
        using (MemoryStream s = new MemoryStream(raw)){
          XmlSerializer xser = new XmlSerializer(typeof(T));
          return xser.Deserialize(s) as T; 
        }
      }
    }
    
    public ForwardMessage : PayloadType{
      public override SomePayloadMethods(){
      }
    }
