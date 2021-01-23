    public interface IPersistable{
        bool ShouldPersist {get;}
    }
    public class MyPersistable:IPersistable
    {
        private bool _persist;
        public MyPersistable(){}
        public string MyValue{
            get{
                return _myValue;
            }
            set{
                _persist = true;// or validate with !IsNullOrEmpty() first
                _myValue = value;
            }
        }
        public bool ShouldPersist{
            get{
                return _persist;
            }
        }
    }
