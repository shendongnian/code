    class MainWindow : Window
    {
        Task calcTask = null;
        void buttonStartCalc_Clicked(object sender, EventArgs e) { StartCalc(); } // #1
        async void buttonDoCalc_Clicked(object sender, EventArgs e) // #2
        {
            await CalcAsync(); // #2
        }
        void StartCalc()
        {
            var calc = PrepareCalc();
            calcTask = Task.Run(() => calc.TestMethod(input)); // #3
        }
        Task CalcAsync()
        {
            var calc = PrepareCalc();
            return Task.Run(() => calc.TestMethod(input)); // #4
        }
        CalcClass PrepareCalc()
        {
            //your code
            var calc = new CalcClass();
            calc.ProgressUpdate += (s, e) => Dispatcher.Invoke((Action)delegate()
                {
                    // update UI
                });
            return calc;
        }
    }
    
    class CalcClass
    {
        public event EventHandler<EventArgs<YourStatus>> ProgressUpdate; // #5
    
        public TestMethod(InputValues input)
        {
            //part 1
            ProgressUpdate.Raise(this, status); // #6 - status is of type YourStatus
            //part 2
        }
    }
    static class EventExtensions
    {
		public static void Raise<T>(this EventHandler<EventArgs<T>> theEvent,
                                    object sender, T args)
		{
			if (theEvent != null)
				theEvent(sender, new EventArgs<T>(args));
		}
    }
