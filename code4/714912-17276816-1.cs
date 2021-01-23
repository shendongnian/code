    class Program
    {
        const int NUM_WAVES = 5;
        const double WAVES_LENGTH = 20;
        const double WAVE_WIDTH = 20;
        static  void Main(string[] args)
        {
            string s = "";
            for (int waves = 0; waves < NUM_WAVES; waves++)
            {
                for (double i = 0; i < WAVES_LENGTH; i++)
                {
                    int width = (int)((Math.Cos((i / WAVES_LENGTH) * 360 * Math.PI / 180)) * WAVE_WIDTH);
                    s = BuildSpace(width + (int)WAVE_WIDTH);
                    Task.Delay(25).Wait();
                    Console.WriteLine(s + "g");
                }
            }
            Console.ReadLine();
        }
        private static string BuildSpace(int i)
        {
            string s="";
            for (int y = 0; y < i; y++)
                s += " ";
            return s;
        }
    }
