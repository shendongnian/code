    public class ElectricDuck
    {  
        public void TurnOn()
        {  
            this.IsTurnedOn = true;
        }
      
        public bool IsTurnedOn { get; set; }  
      
        public IDuck GetIDuck()
        {
            if (!IsTurnedOn)
                throw new InvalidOperationException();
            return new InitializedElectricDuck();  // pass arguments to constructor if required
        }
        private class InitializedElectricDuck : IDuck
        {
            public void Swim()
            {
                // swim logic
            }
        }
    }  
