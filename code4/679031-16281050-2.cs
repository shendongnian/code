    abstract class Cake
    {
        public virtual bool Edible { get { return true; } }
    }
    class PooCake : Cake
    {
        public new bool Edible { get { return false; } }
    }
    class TurdCake : Cake
    {
        public override bool Edible { get { return false; } }
    }
