    public interface IDuck
    {
        bool CanSwim { get; }
        void Swim();
    }
    public class Duck : IDuck
    {
        public void Swim()
        {
            //do something to swim
        }
    
        public bool CanSwim { get { return true; } }
    }
    public class ElectricDuck : IDuck
    {
        public void Swim()
        {
            //swim logic  
        }
    
        public void TurnOn()
        {
            this.IsTurnedOn = true;
        }
    
        public bool IsTurnedOn { get; set; }
        public bool CanSwim { get { return IsTurnedOn; } }
    }
