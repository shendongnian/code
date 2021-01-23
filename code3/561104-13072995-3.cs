    using System;
    using System.Collections.Generic;
    public interface IWaffle { string Eat(); }
    // In this case I define this extra inteface which is non-generic
    // And inside it, we need a new method equivalent to the one on the generic one
    public interface IPlateNG { IWaffle GetWaffle(); }
    // And make the generic one implement the non-generic one
    public interface IPlate<T> : IPlateNG where T : IWaffle { T GetMyWaffle(); }
    public class BelgiumWaffle : IWaffle {
        public string Eat() { return "Eating a Belgium Waffle"; }
        public string Breakfast() { return "Breakfasting a Belgium Waffle"; }
    }
    public class FalafelWaffle : IWaffle {
        public string Eat() { return "Eating a Falafel Waffle"; }
        public string Dinner() { return "Having dinner with a Falafel Waffle"; }
    }
    public class HugePlate : IPlate<BelgiumWaffle> {
        // This extra method is needed due the lack of the 'out' on the definition
        public IWaffle GetWaffle() { return GetMyWaffle(); }
        public BelgiumWaffle GetMyWaffle() { return new BelgiumWaffle(); }
    }
    public class SmallPlate : IPlate<FalafelWaffle> {
        // This extra method is needed due the lack of the 'out' on the definition
        public IWaffle GetWaffle() { return GetMyWaffle(); }
        public FalafelWaffle GetMyWaffle() { return new FalafelWaffle(); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // The list cannot work with the IPlate<IWaffle> anymore. So here comes IPlateNG to the rescue
            var plates = new List<IPlateNG>();
            plates.Add(new HugePlate());
            plates.Add(new SmallPlate());
            IPlateNG aPlate = plates[0];
            // And instead of calling to the GetMyWaffle method we can call to the GetWaffle in this case
            IWaffle aWaffle = aPlate.GetWaffle();
            Console.WriteLine(aWaffle.Eat());
            IPlate<FalafelWaffle> aSmallPlate = (SmallPlate)plates[1];
            FalafelWaffle aFalafel = aSmallPlate.GetMyWaffle();
            Console.WriteLine(aFalafel.Dinner());
        }
    }
