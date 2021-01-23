    public class Program
    {
        private static InterruptPort button = new InterruptPort(Pins.GPIO_PIN_D1, true, Port.ResistorMode.PullUp, Port.InterruptMode.InterruptEdgeLevelHigh);
   
        private static OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);
    
        public static void Main()
        {            
            button.OnInterrupt += new NativeEventHandler(ButtonEvent);
    	    Thread.Sleep(Timeout.Infinite);
        }
    
        private static void ButtonEvent(uint port, uint state, DateTime time)
        {
            ... do whatever here ...
        }
    }
