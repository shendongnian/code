    public Struct MyStruct { 
        public float x { get; private set; }
        public bool initialized { get; private set; }
    
        public MyStruct(float _x){
            x=_x;
            initialized = true;
        }
    }
