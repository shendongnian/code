        private static event EventHandler<EventArgs> _testEvent;
        private static async Task Main()
        {
            var eventObservable = Observable
                .FromEventPattern<EventArgs>(
                    h => _testEvent += h,
                    h => _testEvent -= h);
            Task.Delay(5000).ContinueWith(_ => _testEvent?.Invoke(null, new EventArgs()));
            var res = await eventObservable.FirstAsync();
            Console.WriteLine("Event got fired");
        }
