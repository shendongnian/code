    public class students : INotifyPropertyChanged
    {
        #region PropertyChanged EventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        void NotifyPropertyChanged(String Property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
        }
        #endregion
        private List<GetStudents_Result> stdb;
        public List<GetStudents_Result> std
        {
            get { return stdb; }
            set { stdb = value; NotifyPropertyChanged("std"); }
        }
        ...
