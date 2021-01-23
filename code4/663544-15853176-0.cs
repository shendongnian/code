    abstract class BaseClass<TDERIVED>
    {
        private static Dictionary<Type, int> sampleDictionary_ = new Dictionary<Type, int>();
        public BaseClass()
        {
        }   // eo ctor
        public int Sample
        {
            get
            {
                return sampleDictionary_.ContainsKey(typeof(TDERIVED)) ? sampleDictionary_[typeof(TDERIVED)] : 0;
            }
            set
            {
                sampleDictionary_[typeof(TDERIVED)] = value;
            }
        }
    }
    class ChildClass1 : BaseClass<ChildClass1>
    {
    }
    class ChildClass2 : BaseClass<ChildClass2>
    {
    }
