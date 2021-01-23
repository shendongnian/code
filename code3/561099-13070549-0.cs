        public interface IWaffle { }
        public interface IPlate<out T> where T : IWaffle { }
        public interface IPancake : IWaffle { }
        public class BelgiumWaffle : IWaffle {}
        public class FalafelWaffle : IWaffle {}
        public class HugePlate : IPlate<BelgiumWaffle> {}
        public class SmallPlate : IPlate<FalafelWaffle> { }
        var plates = new List<IPlate<IWaffle>>();
        plates.Add(new HugePlate());
        plates.Add(new SmallPlate());
