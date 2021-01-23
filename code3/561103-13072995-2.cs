    using System;
    using System.Collections.Generic;
    public interface IWaffle { string Eat(); }
    // on C# 4.0 you just put the "out" to mark the covariance (and that is it)
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
            // Anyway, when you get a member of the collection you'll get the interface, not a concrete class (obviously).
            IWaffle aWaffle = aPlate.GetMyWaffle();
            // So you cannot invoke any specifics (like Breakfast or Dinner)
            Console.WriteLine(aWaffle.Eat());
            // But if you cast the member of the collection to the specific class (or interface)
            IPlate<FalafelWaffle> aSmallPlate = (SmallPlate)plates[1];
            // Then you'll get the concrete class without casting again
            FalafelWaffle aFalafel = aSmallPlate.GetMyWaffle();
            Console.WriteLine(aFalafel.Dinner());
        }
    }
