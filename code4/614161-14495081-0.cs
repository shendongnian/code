        class Decorator
    {
        private object instance;
        public Decprator(object instance)
        {
             this.instance = instance;
        }
        
        public <type> SomeCommonProp
        {
          get{
            if(instance is DogActivityType)
            {
              return (instance as DogActivityType).SomeValueOrPropertyOrCall;
            }
            else
            {
              return (instance as HorseActivityType).SomeValueOrPropertyOrCall; 
            }
          }
        }
    }
    class MyCalculations
    {
      private Decorator instance;
      
      public MyCalculations(Decorator inst)
      {
          instance = inst;
      }
      public <type> SomeCalculationMethod()
      {
        // here you will use instance.SomeCommonProp for your calculations
      }
    }
