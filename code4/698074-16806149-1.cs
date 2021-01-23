    public class myViewModel : INotifyPropertyChanged
    {
        public bool IsOk { get; set; }
        public string Message { get; set; }
        public RelayCommand OnValidateExecute { get; set; }
    
        public myViewModel()
        {
            OnValidateExecute = new RelayCommand(p => 
                {
                    Message = p as string;
                    IsValid();
                }, p => true);
        }
    
        public bool IsValid()
        {
            bool valid = !string.IsNullOrEmpty(Message);
            IsOk = valid;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("IsOk"));
            }
            return valid;
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    }
