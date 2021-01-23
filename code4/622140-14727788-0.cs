    public class Test
    {
     public Test()
      {
         var dict=new Dictionary<MessageType,Func<Buffer,Mesage>>();
         var types=from a in AppDomain.CurrentDomain.GetAssemblies()
             from t in a.GetTypes()
             where t.IsDefined(MessageTypeAttribute, inherit)
             select t;
        foreach(var t in types) {
          var attr = t.GetCustomAttributes(typeof (MessageTypeAttribute), false).First();
           dict[attr.MessageType] = CreateFactory(t);
           }
          var msg=dict[MessageType.Chat](Buf);
      }
     Func<Buffer,Message> CreateFactory(Type t)
     {
          var arg = Expression.Parameter(typeof (Buffer));
            var newMsg = Expression.New(t.GetConstructor(new[] {typeof (Buffer)}),arg);
            return Expression.Lambda<Func<Buffer, Message>>(newMsg, arg).Compile();
    }
     
    }
            
