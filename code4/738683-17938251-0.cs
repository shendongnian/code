    class LeapEventInterpretator
    {
        private Controller controller;
        private DeviceEventListener deviceEventListener;
    
        public delegate void LeapEventHandler(object sender, Gesture args);
        public event LeapEventHandler GestureDetected;
    
        public LeapEventInterpretator()
        {
            Connect();    
        }
        private void Connect()
        {
            controller = new Controller();
    
            // pass a callback that will raise the event.
            deviceEventListener = new DeviceEventListener(RaiseGestureDetected);
            controller.AddListener(deviceEventListener);
    
        }
    
        // a method to raise the event
        private void RaiseGestureDetected(Gesture gesture)
        {
             var handler = GestureDetected;
             if (handler != null)
                 handler(this, gesture);
        }
    
        public enum Gesture { SwipeLeft, SwipeRight };
    }
    
    class DeviceEventListener : Listener
    {
        Action<LeapEventInterpretator.Gesture> handler;
        public DeviceEventListener(Action<LeapEventInterpretator.Gesture> h)
        {
            this.handler = h;
        }
        public override void OnConnect(Controller arg0)
        {
            if (this.handler != null)
                handler(LeapEventInterpretator.Gesture.SwipeLeft);
        }
    }
