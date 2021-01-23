    using ManagedBass;
     
    class Program
    {
        static void Main()
        {
            Bass.Init(); // Initialize with default options.
     
            int handle = Bass.CreateStream("YOUR_FILE.mp3");
     
            Bass.ChannelPlay(handle); // Begin Playback.
     
            Console.ReadKey(); // Wait till user presses a Key.
     
            Bass.ChannelStop(handle); // Stop Playback.
     
            Bass.ChannelFree(handle); // Free the Stream.
     
            Bass.Free(); // Free the device.
        }
    }
