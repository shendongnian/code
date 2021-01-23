    class Program {
        static bool isFinished = false;
        static void Main(string[] args) {
            // Kick off the background operation and don't care about when it completes
            BackgroundWork();
            Console.WriteLine("Press enter when you're ready to stop the background operation.");
            Console.ReadLine();
            isFinished = true;
        }
        // Using async void to kickoff a background operation that nobody wants to be notified about when it completes.
        static async void BackgroundWork() {
            // It's important to catch exceptions so we don't crash the appliation.
            try {
                // This operation will end after ten interations or when the app closes. Whichever happens first.
                for (var count = 1; count <= 10 && !isFinished; count++) {
                    await Task.Delay(1000);
                    Console.WriteLine($"{count} seconds of work elapsed.");
                }
                Console.WriteLine("Background operation came to an end.");
            } catch (Exception x) {
                Console.WriteLine("Caught exception:");
                Console.WriteLine(x.ToString());
            }
        }
    }
