        public class WithEvent
        {
            // this is the new published event
            public EventHandler<EventArgs> NewMouseEvent;
            // This handles the original mouse event of the inner class
            public void OriginalEventhandler(object sender, EventArgs e)
            {
                // this raises the published event (if susbcribedby any handler)
                if (NewMouseEvent != null)
                {
                    NewMouseEvent(this, e);
                }
            }
        }
        public class Subscriber
        {
            public void Handler(object sender, EventArgs e)
            {
                // this is the second class handler
            }
            public void Subscribe()
            {
                WithEvent we = new WithEvent();
                // This is how you subscribe the handler of the second class
                we.NewMouseEvent += Handler;
            }
        }
