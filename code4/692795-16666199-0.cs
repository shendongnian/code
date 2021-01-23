    class AnotherInterfaceImpl : AnotherInterface
    {
        private MyInterfaceImpl _member1;
        public MyInteface member1
        {
            get{ return _member1;}
            set{ _member1 = value;}
        }
    
        ...Other implementation
    }
