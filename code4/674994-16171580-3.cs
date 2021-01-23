    public class Message{
          public int Prefix {get; private set;}
          public byte[] RawPayload {get;private set;}
        
          public PayloadType GetPayload(){
            PayloadType result = null;
            switch (Prefix){ // you can also convert that to enum and use "if" for more complicated identification
              case 1: 
                result = PayloadType.FromRaw<ForwardMessage>(RawPayload);
                break;
              case 2: 
                result = PayloadType.FromRaw<ArchiveMessage>(RawPayload);
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
          public abstract MessageType MessageType {get;} // enum goes better here
          public abstract Process();
        
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
          public override MessageType MessageType {return MessageType.Forward;}
          public override Process(){
              // send this message elsewhere
          }
        }
        public ArchiveMessage: PayloadType{
          public override MessageType MessageType {return MessageType.Archive;}
          public override Process(){
               // store this message somehow
          }
        }
        
        public enum MessageType{
            Unknown, Formward, Archive,
        }
