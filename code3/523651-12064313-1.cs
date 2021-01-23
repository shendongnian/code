        public class Caller
        {
            private Module1.MyDiscriminatedUnion _item;
    
            public Caller(Module1.MyDiscriminatedUnion item)
            {
                _item = item;
            }
    
            public string DoThing()
            {
                object result = _item; //assign to object
                return result.ToString(); //call ToString() on object
            }
    
            public string DoOtherThing()
            {
                return _item.ToString(i => i.ToString());
            }
        }
