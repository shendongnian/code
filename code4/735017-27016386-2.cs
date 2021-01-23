    public class TextChangeEventArgs : EventArgs
    {
        private string strDataToPass;
    
        public TextChangeEventArgs(string _text)
        {
            this.strDataToPass = _text;
        }
            
        public string prpStrDataToPass
        {
            get { return strDataToPass; }
        }
    }
