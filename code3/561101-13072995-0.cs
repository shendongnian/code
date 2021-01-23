    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        public interface IWaffle { string Eat(); }
        public interface IPlate<out T> where T : IWaffle { T GetMyWaffle(); }
    
        public class BelgiumWaffle : IWaffle {
            public string Eat() { return "Eating a Belgium Waffle"; }
            public string Breakfast() { return "Breakfasting a Belgium Waffle"; }
        }
        public class FalafelWaffle : IWaffle {
            public string Eat() { return "Eating a Falafel Waffle"; }
            public string Dinner() { return "Having dinner with a Falafel Waffle"; }
        }
        public class HugePlate : IPlate<BelgiumWaffle> {
            public BelgiumWaffle GetMyWaffle() { return new BelgiumWaffle(); }
        }
        public class SmallPlate : IPlate<FalafelWaffle> {
            public FalafelWaffle GetMyWaffle() { return new FalafelWaffle(); }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var plates = new List<IPlate<IWaffle>>();
                plates.Add(new HugePlate());
                plates.Add(new SmallPlate());
    
                IPlate<IWaffle> aPlate = plates[0];
                IWaffle aWaffle = aPlate.GetMyWaffle();
                Console.WriteLine(aWaffle.Eat());
    
                IPlate<FalafelWaffle> aSmallPlate = (SmallPlate)plates[1];
                FalafelWaffle aFalafel = aSmallPlate.GetMyWaffle();
                Console.WriteLine(aFalafel.Dinner());
    
                Console.ReadKey();
            }
        }
    }
