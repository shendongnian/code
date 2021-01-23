    using ManagedBass;
     
    class Program
    {
        static void Main()
        {
            using (var Player = new MediaPlayer()) // Create a Player.
            {
                Player.Load("YOUR_FILE.mp3"); // Load a file.
     
                Player.Start(); // Begin Playback.
     
                Console.ReadKey();
            }
        }
    }
