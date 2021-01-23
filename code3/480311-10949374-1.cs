        private static async void WorkAsync()
        {
            await DoSomeWork();
            if (await DoSomeMoreWork())
            {
                await DoFinalWork();
            }
        }
        private static async Task DoFinalWork()
        {
            Console.WriteLine("Completed");
        }
        private static async Task<bool> DoSomeMoreWork()
        {
            Console.WriteLine("Some More");
            return true;
        }
        private static async Task DoSomeWork()
        {
            Console.WriteLine("Some");
        }
