     public class ResourceMock:INotifyPropertyChanged
    {
        public string Title
        {
            get
            {
                MessageBox.Show(Thread.CurrentThread.CurrentCulture.Name);
                switch (Thread.CurrentThread.CurrentCulture.Name)
                {
                    case "en-GB": return "English"; break;
                    case "pl-PL": return "Polish"; break;
                    default: return "default";
                        break;
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public void firePropertyChanged(string property)
        {
            OnPropertyChanged(property);
        }
    }
