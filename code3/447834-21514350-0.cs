    [Serializable]
    public class Foo{
         
       [OnSerializing]
       public void DebugHook(StreamingContext context){
         //here goes magic stuff...
       }
    }
