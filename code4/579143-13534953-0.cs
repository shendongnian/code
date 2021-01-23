    namespace Cars
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Cars> carList = new List<Cars>();
                
                Console.WriteLine("PLz put the car  name:");
                string ma = Console.ReadLine();
                Console.WriteLine("PLz put  car no  :");
                 int pe = Convert.ToInt16(Console.ReadLine());
    
                carList.Add(new Cars(ma,pe));
            }
    
          
    
            public class Cars
            {
    
                string ma;
                int pe;
    
                public Cars(string carName, int reg)
                {
                    ma = carName;
                    pe = reg;
                    
                }
    
            }
        }
    }
