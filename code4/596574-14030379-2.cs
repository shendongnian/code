    public class ListViewModal : INotifyPropertyChanged
    {
        public List<CheckList> ListOftext { get; set; }
        public ListViewModal() 
        {
            ListOftext = new List<CheckList>();
            ListOftext.Add(new CheckList() { DisplayName = "Hi this is windows phone" });
            ListOftext.Add(new CheckList() { DisplayName = "Hi this is android" });
            ListOftext.Add(new CheckList() { DisplayName = "Hi this is Iphone" });
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
    }
