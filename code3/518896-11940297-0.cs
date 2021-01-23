    class Parent : ICloneable
    {
        int x;    
        public Parent(int _x)
        {
            x = _x
        }
 
        public virtual object Clone()
        {
            return new Parent(x);
        }
    }
    
    class Child1 : Parent
    {
        int y;
    
        public Child1(int _y) : base(_y)
        {
            y = _y;
        }
 
        public override object Clone()
        {
            return new Child1(y);
        }
    }
    
    class Child2 : Parent
    {
        int z;
    
        public Child2(int _z) : base(_z)
        {
            z = _z;
        }
 
        public override object Clone()
        {
            return new Child2(z);
        }
    }
