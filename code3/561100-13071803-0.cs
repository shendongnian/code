    public abstract class Waffle { }
    public interface IPlate<T> where T : Waffle
    {
        T Food
        {
            get;
            set;
        }
    }
    public class BelgiumWaffle : Waffle { }
    public class FalafelWaffle : Waffle { }
    public class HugePlate<T> : IPlate<T> where T : Waffle
    {
        public HugePlate(T food)
        {
            this.Food = food;
        }
        public T Food
        {
            get;
            set;
        }
    }
    public class SmallPlate<T> : IPlate<T> where T : Waffle
    {
        public SmallPlate(T food)
        {
            this.Food = food;
        }
        public T Food
        {
            get;
            set;
        }
    }
    public class Test
    {
        Test()
        {
            var platesOfWaffle = new List<IPlate<Waffle>>();
            platesOfWaffle.Add(new HugePlate<Waffle>(new BelgiumWaffle()));
            platesOfWaffle.Add(new SmallPlate<Waffle>(new FalafelWaffle()));
        }
    }
