    public class MyListEntryViewModel : ViewModel
    {        
        public string ClientName
        {
            get { return clientName; }
            set
            {
                if (clientName != value)
                {
                    clientName = value;
                    OnPropertyChanged("ClientName");
                }
            }
        }
        private string clientName;
        // the rest of bindable properties (ApplicationName, StartPicker, etc.)
        public bool HasChanges
        {
            get { return hasChanges; }
            set
            {
                if (hasChanges != value)
                {
                    hasChanges = value;
                    OnPropertyChanged("HasChanges");
                }
            }
        }
        private bool hasChanges;
        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName != "HasChanges")
            {
                HasChanges = true;
            }
        }
    }
