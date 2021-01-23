    namespace MyProject
    {
      public class Herp : INotifyPropertyChanged
      {
        private string m_derp;
        public Herp()
        {
        }
        public string DerpDerp
        {
            get { return m_derp; }
            set { m_derp = value; OnPropertyChanged("DerpDerp"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
