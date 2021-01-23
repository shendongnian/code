    using System;
    using System.ComponentModel;
    [Serializable]
    public class MyClass
    {
        //property for usage in code. dont serialize
        [NonSerialized]
        public List<BaseValidator> MyList { get; set; }
    
        // Property for serialization only
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BaseValidator[] MyArray
        {
            get
            {
                return MyList.ToArray();
            }
            set
            {
                MyList = new List<BaseValidator>(value);
            }
        }
    }
