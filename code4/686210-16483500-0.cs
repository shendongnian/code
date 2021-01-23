    public class Foo  
    {  
        #region Variables / Properties
    
        public bool Bar { get; set; }
        public string Name { get; set; }
        public int Fooby { get; set; }
    
        #endregion Variables / Properties
    
        #region Prototypes
    
        static private Foo _SomePrototype = new Foo
        {
            Bar = false,
            Name = "Generic False State",
            Fooby = -1
        };
    
        static private Foo _SomeOtherPrototype = new Foo
        {
            Bar = true,
            Name = "Generic True State",
            Fooby = Int32.MaxValue
        };
    
        static public Foo SomePrototype 
        {
            get
            {
                return _SomePrototype;
            }
        }
    
        static public Foo SomeOtherPrototype 
        {
            get
            {
                return _SomeOtherPrototype;
            }
        }
        #endregion
    }
