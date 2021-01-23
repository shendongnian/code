     public class ViewModel : INotifyPropertyChanged
    {
        private List<string> m_ComboItems= new List<string>();
        private string m_SelectedItem;
        public ViewModel()
        {
            m_ComboItems.Add("AA");
            m_ComboItems.Add("BB");
            m_ComboItems.Add("CC");
            this.SelectedItem = m_ComboItems.First<string>();
        }
        public List<string> ComboItems
        {
            get { return m_ComboItems;}            
        }
        public string SelectedItem
        {
            get { return m_SelectedItem; }
            set
            {
                m_SelectedItem = value;
                this.OnPropertyChanged("SelectedItem");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
