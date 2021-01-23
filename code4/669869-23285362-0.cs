        static void Main(string[] args)
        {
            Action testAction = async () =>
            {
                Console.WriteLine("In");
                await Task.Delay(100);
                Console.WriteLine("First delay");
                await Task.Delay(100);
                Console.WriteLine("Second delay");
            };
            testAction.Invoke();
            Thread.Sleep(150);
        }
