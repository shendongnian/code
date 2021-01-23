      class Animal {
        public virtual void eat()
        {
          Console.WriteLine("Animal.eat()");
        }
      }
      class Tiger : Animal {
        public override void eat()
        {
          Console.WriteLine("Tiger.eat()");
        }
      }
      class SomethingElse {
        protected virtual void Eat<AnimalType>(Animal animal) 
        where AnimalType : Animal
         {
           AnimalType myDerivedAnimal = animal as AnimalType;
           if (myDerivedAnimal != null)
           {
               myDerivedAnimal.eat();
           }
        }
        public void Test()
        {
          var myTiger = new Tiger();
          Eat<Tiger>(myTiger);
        } // Test
      }
      class Program {
        static void Main(string[] args)
        {
          new SomethingElse().Test();
        }
      }
