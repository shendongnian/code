    public class TheTimer
    {
        // define delegate with desired parameters
        public delegate void TimerDelegate(int param1, string param2);
        // expose the event
        public event TimerDelegate OnTimer;
        // This is the handler of a regular Timer tick:or your OnCreate() function
        Timer1_Tick()
        {
            if (OnTimer != null) // if susbcribed handlers
            {
                OnTimer(1, "value"); // raise your cutom event, passing the params
            }
        }
    }
    // Implement classes with functions that can handle the event
    public class HandlerFunctions
    {
        public void HandleTimer(int p, string p2)
        {
           // do whatever   
        }
    }
    // Use your classes
    public class TimerUserClass
    {
        public static void UseTimers()
        {
            // Create objects
            TheTimer theTimer = new TheTimer();
            HandlerFunctions handler1 = new HandlerFunctions();
            HandlerFunctions handler2 = new HandlerFunctions();
            // SUbscribe events
            theTimer.OnTimer += handler1.HandleTimer;
            theTimer.OnTimer += handler2.HandleTimer;
            // un-susbcribe
            theTimer.OnTimer -= handler1.HandleTimer;
        }
    }
