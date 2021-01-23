    public class TextBlockInfo : INotifyPropertyChanged
    {
        //member variables
        private string m_sText = "";
        private string m_sTextColorName = "";
    
        //construction
        public TextBlockInfo() { }
        public TextBlockInfo(string sText, string sTextColorName)
        {
            m_sText = sText;
            m_sTextColorName = sTextColorName;
        }
    
        //events
        public event PropertyChangedEventHandler PropertyChanged;
    
        //properties
        public string Text { get { return m_sText; } set { m_sText = value; this.NotifyPropertyChanged("Text"); } }
        public string TextColorName { get { return m_sTextColorName; } set { m_sTextColorName = value; this.NotifyPropertyChanged("TextColorName"); } }
    
        //methods
        private void NotifyPropertyChanged(string sName)
        {
            if (this.PropertyChanged != null) this.PropertyChanged(this, new PropertyChangedEventArgs(sName));
        }
    }
