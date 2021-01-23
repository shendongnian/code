    static void Main(string[] args)
            {
                Random rnd = new Random();
                string[] Colors = new string[10] { "Red", "Yellow", "Green", "Blue", "Purple", "White", "violet", "orange", "indigo", "blue" };
                for (int i = 0; i < 13; i++)
                {
                    int code = rnd.Next(0, 9);
                    string Color = Colors[code];
                    Console.WriteLine(Color);
                }
                Console.ReadLine();
            }
