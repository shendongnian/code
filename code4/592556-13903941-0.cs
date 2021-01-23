    static void Main(string[] args)
            {
                Random getal = new Random();
                int[] lottotrekking = new int[6];
    
                var getals = new List<int>();
    
                Console.WriteLine("Geef je geluksgetallen in <tussen 1 en 42>");
                Console.WriteLine("Geef je eerste getal in");
                getals.Add(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Geef je tweede getal in");
                getals.Add(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Geef je derde getal in");
                getals.Add(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Geef je vierde getal in");
                getals.Add(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Geef je vijfde getal in");
                getals.Add(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Geef je zesde getal in");
                getals.Add(Convert.ToInt32(Console.ReadLine()));
    
    
                bool match = false;
                while (!match)
                {
                    //Reset the array
                    lottotrekking = new int[6];
                    for (int i = 0; i < lottotrekking.Length; i++)
                    {
    
                        //Make sure we dont add one number several times
                        int cijfer = 0;
                        while (lottotrekking.Any(x => x == cijfer) || cijfer == 0)
                        {
                            cijfer = getal.Next(1, 43);
                        }
                        lottotrekking[i] = cijfer;
                        
                    }
                    Console.WriteLine(lottotrekking[0] + "\t " + lottotrekking[1] + "\t " + lottotrekking[2] + "\t " + lottotrekking[3] + "\t " + lottotrekking[4] + "\t " + lottotrekking[5]);
    
                    match = lottotrekking.All(getals.Contains);
    
                }
    
                Console.WriteLine(lottotrekking[0] + " " + lottotrekking[1] + " " + lottotrekking[2] + " " + lottotrekking[3] + " " + lottotrekking[4] + " " + lottotrekking[5]);
                
    
                Console.ReadLine();
    
    
            }
        }
