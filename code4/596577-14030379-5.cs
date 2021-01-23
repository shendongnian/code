    public class ListViewModal : INotifyPropertyChanged
    {
        public List<CheckList> ListOftext { get; set; }
        public ListViewModal(IEnumerable<Contact> iEnumerable)
        {
            ListOftext = new List<CheckList>();
            foreach (var list in iEnumerable) 
            {
                ListOftext.Add(new CheckList(){DisplayName = list.DisplayName});
            }
            RaisePropertyChanged("ListOftext");
        }
        
        /// <summary>
        /// Property changed method
        /// Executes when a property changes its value
        /// </summary>
        /// <param name="propertyName"></param>
        public void RaisePropertyChanged(string propertyName)
        {
            // this is the property changed method 
            //to detect property change
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private IEnumerable<Contact> iEnumerable;
    }
