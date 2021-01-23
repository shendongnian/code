        // You can add more parameters to this to pass any data you need
        // in addition to the object sender you pass back
        public delegate void UpdateEventHandler(object sender, EventArgs e)
        public class FormB : Form
        {
            public event UpdateEventHandler Update;
            private void update()
            {
                // do your updates to formB here
                InvokeUpdateEvent(objectThatContainsUsefulData);
            }
            protected void InvokeUpdateEvent(object sender)
            {
                var handler = UpdateEvent;
                if (handler != null)
                    handler(sender, null);
            }
        }
