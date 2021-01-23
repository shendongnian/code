    using ProtoBuf.Meta;
    using System;
    class UserEvent<T> :Event where T:Request
    {
        public override string ToString()
        { // to show what we are working with
            return "UserEvent-of-" + typeof (T).Name;
        }
    }
    
    // infer the : Request here from the ^^^^
    class Message : Request{}
    class Like : Request { }
    class Tag : Request { }
    
    class ScsMessage {}
    // infer : ScsMessage here from the 2 AddSubType
    class Request : ScsMessage {}
    class Event : ScsMessage { }
    
    class Program
    {
    
        static void Main()
        {
            var Model = TypeModel.Create();
            Model.Add(typeof(ScsMessage), true).AddSubType(20, typeof(Request));
            Model.Add(typeof(ScsMessage), true).AddSubType(200, typeof(Event));
    
            Model.Add(typeof(Request), true).AddSubType(102, typeof(Message));
            Model.Add(typeof(Request), true).AddSubType(103, typeof(Like));
            Model.Add(typeof(Request), true).AddSubType(104, typeof(Tag));
    
            Model.Add(typeof(Event), true).AddSubType(202, typeof(UserEvent<Message>));
            Model.Add(typeof(Event), true).AddSubType(203, typeof(UserEvent<Like>));
            Model.Add(typeof(Event), true).AddSubType(204, typeof(UserEvent<Tag>));
    
            var obj = new UserEvent<Like>();
    
            var clone = Model.DeepClone(obj);
            Console.WriteLine(obj);
            Console.WriteLine(clone);
        }
    }
