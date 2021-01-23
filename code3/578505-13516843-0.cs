        class Client
    {
        static void Main(string[] args)
        {
            try
            {
                BikeReference.BikeSalesClient bikeRef = new BikeClient.BikeReference.BikeSalesClient();
                String menu = "\n\nEnter:\n" +
                    "0 to get all the bike stock;\n" +
                    "1 to get all the bike types;\n" +
                    // ...
                    "8 to quit:\n";
    
                Console.WriteLine(menu);
    
                    // will throw FormatException if not int
                    int entry = int.Parse(Console.ReadLine());
    
                do
                {
                    switch (entry)
                    {
                        case 0:
                            foreach (var obj in bikeRef.GetAllBikeStock())
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Bike ID: {0}", obj.IdBikeStock);
                                Console.WriteLine("Bike Type ID: {0}", obj.IdBikeType);
                                // ...
                                Console.WriteLine("Sold: {0}", obj.isItSold);
                                //break;
                            }
                            break;
    
                        case 1:
                            Console.WriteLine(bikeRef.UpdateBikeStock(15));
                            break;
    
                        default:
                            Console.WriteLine("Unrecognised option...");
                            break;
                    }
                entry = int.Parse(Console.ReadLine());
                }
                while (entry != 7);
            }
    
            catch (Exception)//(Exception e)
            {
               // Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
