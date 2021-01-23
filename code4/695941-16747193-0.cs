        static void Main()
        {
           SystemEvents.PowerModeChanged += OnPowerModeChanged;
           Console.ReadLine(); //just wait, don't exit immediately.
        }
        private static void OnPowerModeChanged(object sender, PowerModeChangedEventArgs e) 
        {
            //Handle the event here.
        }
