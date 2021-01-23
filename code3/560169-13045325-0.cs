       using System;
       using System.Threading;
        public class TimerExample {
    // The method that is executed when the timer expires. Displays
    // a message to the console.
    private static void TimerHandler(object state) {
        Console.WriteLine("{0} : {1}",
            DateTime.Now.ToString("HH:mm:ss.ffff"), state);
    }
    public static void Main() {
        // Create a new TimerCallback delegate instance that 
        // references the static TimerHandler method. TimerHandler 
        // will be called when the timer expires.
        TimerCallback handler = new TimerCallback(TimerHandler);
        // Create the state object that is passed to the TimerHandler
        // method when it is triggered. In this case a message to display.
        string state = "Timer expired.";
        Console.WriteLine("{0} : Creating Timer.",
            DateTime.Now.ToString("HH:mm:ss.ffff"));
        // Create a Timer that fires first after 2 seconds and then every
        // second.
        using (Timer timer = new Timer(handler, state, 2000, 1000)) {
            int period;
            // Read the new timer interval from the console until the
            // user enters 0 (zero). Invalid values use a default value
            // of 0, which will stop the example.
            do {
                try {
                    period = Int32.Parse(Console.ReadLine());
                } catch {
                    period = 0;
                }
                // Change the timer to fire using the new interval starting
                // immediately.
                if (period > 0) timer.Change(0, period);
            } while (period > 0);
        }
        // Wait to continue.
        Console.WriteLine("Main method complete. Press Enter.");
        Console.ReadLine();
    }
    }
