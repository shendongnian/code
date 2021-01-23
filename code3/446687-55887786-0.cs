    class Program
    {
        static void Main(string[] args)
        {
            ICar smallCar = Helper.GetCar<SmallCar>("car 1");
            ICar mediumCar = Helper.GetCar<MediumCar>("car 2");
            Console.ReadLine();
        }
    }
    static class Helper
    {
        public static T GetCar<T>(string carName) where T : ICar
        {
            ICar objCar = default(T);
            if (typeof(T) == typeof(SmallCar))
            {
                objCar = new SmallCar { CarName = carName };
            }
            else if (typeof(T) == typeof(MediumCar))
            {
                objCar = new MediumCar { CarName = carName };
            }
            return (T)objCar;
        }
    }
    interface ICar
    {
        string CarName { get; set; }
    }
    class SmallCar : ICar
    {
        public string CarName { get; set ; }
    }
    class MediumCar : ICar
    {
        public string CarName { get; set; }
    }
