    public class Dog : Animal {
       public override bool CanBreathe { get { return !IsUnderWater; } }
    }
    public class Fish : Animal {
       public override bool CanBreathe { get { return IsUnderWater; } }
    }
