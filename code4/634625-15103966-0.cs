     class PrintClass 
    {
        public Action<string> DisplayDelegate;
        
        
        public void printEventHandler(object sender, EventArgs e)
        {
            string text = "Event Handled, and text value is passed";
            var copy = DisplayDelegate;
            if (copy != null)
            {
               copy(text);
            }
        }
    }
