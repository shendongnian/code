    public class StartDateTimePicker : DateTimePicker
    {
        bool handling = false;
        // Note: 
        public StartDateTimePicker()
            : base()
        {
            // This could be simplified to a lambda expression
            this.ValueChanged += new EventHandler(StartDateTimePicker_ValueChanged);
        }
    
        void StartDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // If the value is being changed by this event, don't change it again
            if (handling)
            {
                return;
            }
            try
            {
                handling = true;
                // Add your DateTime adjustment logic here:
                Value = Value.Date;
            }
            finally
            {
                handling = false;
            }
        }
    }
