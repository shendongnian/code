    public interface IExample<out T>
    {
        T TryGetByName(string name, out bool success);
    }
    public static class HelperClass
    {
        public static bool TryGetByName<T>(this IExample<T> @this, string name, out T child)
        {
            bool success;
            child = @this.TryGetByName(name, out success);
            return success;
        }
    }
    public interface IAnimal { };
    public interface IFish : IAnimal { };
    public class XavierTheFish : IFish { };
    public class Aquarium : IExample<IFish>
    {
        public IFish TryGetByName(string name, out bool success)
        {
            if (name == "Xavier")
            {
                success = true;
                return new XavierTheFish();
            }
            else
            {
                success = false;
                return null;
            }
        }
    }
    public static class Test
    {
        public static void Main()
        {
            var aquarium = new Aquarium();
            IAnimal child;
            if (aquarium.TryGetByName("Xavier", out child))
            {
                Console.WriteLine(child);
            }
        }
    }
