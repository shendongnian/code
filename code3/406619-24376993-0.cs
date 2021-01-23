    public class MultipleOpjects
    {
        private List<string> _ObjectOne;
        public List<string> ObjectOne {
            get { return _ObjectOne; }
            set { _ObjectOne = value; }
        }
        private List<object> _ObjectTwo;
        public List<object> ObjectTwo {
            get { return _ObjectTwo; }
            set { _ObjectTwo = value; }
        }
        private object _ObjectThree;
        public object ObjectThree {
            get { return _ObjectThree; }
            set { _ObjectThree = value; }
        }
    }
    public MultipleOpjects GetAnything()
    {
        MultipleOpjects Vrble = new MultipleOpjects();
        Vrble.ObjectOne  = SomeThing1;
        Vrble.ObjectTwo = SomeThing2;
        Vrble.ObjectThree = SomeThing3;
        return Vrble;      
    }
