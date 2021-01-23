     [Serializable()]
     public abstract class AbstractMessage {
         public object Payload { get { return this.GetPayload(); } }
         protected abstract object GetPayload();
     }
     [Serializable()]
     public class Message<T> : AbstractMessage
     {
         // .... etc ....
         public new T Payload
         {
             get { return _payload; }
             set { _payload = value; }
         }
         // .... etc ....
         protected override object GetPayload() { return this.Payload; }
     }  
