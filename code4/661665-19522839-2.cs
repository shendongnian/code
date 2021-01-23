    public class TextChangedEventArgs : EventArgs
    {
        private String text;
        //Did not implement a "Set" so that the only way to give it the Text value is in 
        //the constructor
        public String Text
        {
            get { return text; }
        }
        public TextChangedEventArgs(String theText)
            : base()
        {
            text = theText;
        }
    }
