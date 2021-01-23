    abstract class Animal {
      public abstract void MakeNoise();
    }
    abstract class Dog : Animal { }
    class Labrador : Dog {
      public override void MakeNoise() {
        ...
      }
    }
