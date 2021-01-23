    public class TextChangedArgs:EventArgs
    {
        string _text;
        /// <summary>
        /// Gets text .
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
        {
            get { return _text; }
        }
        public TextChangedArgs(string text)
        {
            this._text = text;
        }
    }
