    public class Localize : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyChange(String name)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion
        #region 'Public Properties'
        //Declarations
        private static Resources.MyResources _myResources = new Resources.MyResources();
        public Resources.MyResources myResources
        {
            get { return _myResources; }
            set { NotifyChange("MyResources"); }
        }
        #endregion
    }
