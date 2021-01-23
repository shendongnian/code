    public class CounterClass
    {
        private int counter;
        // Declare the event
        public event EventHandler CounterValueChanged;
        public CounterChange()
        {
        }
        public CounterChange(int value)
        {
            this.counter = value;
        }
        public int Counter
        {
            get { return counter; }
            set
            {
                //Chaeck if has really changed?
                if(counter != value)
                {
                    counter = value;
                    // Call CounterValueChanged whenever the property is updated
                    //check if there are any subscriber to this event
                    if(CounterValueChanged!=null)
                        CounterValueChanged(this, new EventArgs());
                }
            }
        }
    }
