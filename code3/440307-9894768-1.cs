    abstract class Animal {}
    class Tiger : Animal {}
    class Giraffe : Animal {} 
    class B
    {
        public virtual void M(Tiger x) {}
        public virtual void M(Animal x) {}
    }
    class D : B
    {
        public override void M(Tiger x) {}
        public override void M(Animal x) {}
    }
    ...
    B b = whatever;
    Animal a = new Tiger();
    b.M(a);
