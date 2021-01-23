    public class Child:Parent
    {
        public Child()
        {
            Console.WriteLine("Child ctor()");
            CommonChildConstructionBehaviour();
        }
    
        public Child(int i) : base(i)
        {
            Console.WriteLine("Child ctor(int)");
            CommonChildConstructionBehaviour();
        }
    
        private void CommonChildConstructionBehaviour()
        {
            Console.WriteLine("All child constructors must call me.");
        }
    }
