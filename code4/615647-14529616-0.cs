    namespace mynamespace
    {
        public class FarmAnimal
        {
            public string accountName = "Farm Animals";
        }
        public class Quadruped : FarmAnimal
        {
            public string campaignName = "Quadrupeds";
        }
        public class Dog : Quadruped
        {
            public string documentName = "Best Friend";
            public string destinationName = "Front Porch";
    
            public override string ToString()
            {
                return String.Format("{0} : {1} : {2} : {3}", accountName, campaignName, documentName, destinationName);
            }
        }
    
        public class AnimalFactory
        {
            public static FarmAnimal create(string fileName)
            {
                try {
                    ObjectHandle h = Activator.CreateInstance(null, "mynamespace." + fileName);
                    return  (FarmAnimal)h.Unwrap();
                }
                catch (Exception) {
                    return null;
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                FarmAnimal a = AnimalFactory.create("Dog");
                Console.WriteLine(a);
            }
        }
    }
