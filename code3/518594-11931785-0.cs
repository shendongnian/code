    interface IProperty {
        object Value { get;}
        void DestroyEarth();
    }
    interface IProperty<T> : IProperty {
        T Value { get;}
    }
    class MyProperty : IProperty<int>
    {
        object IProperty.Value { get { return Value; } }
        public int Value{get {return 1;} }
        public void  DestroyEarth(){}
    }
