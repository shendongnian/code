    public class TypeA : INotifyPropertyChanged
    {
        private int i;
        private string s;
        public int I
        {
            get { return i; }
            set { SetField(ref i, value); }
        }
        public string S
        {
            get { return s; }
            set { SetField(ref s, value); }
        }
        private void SetField<T>(ref T field, T value,
            [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                var handler = PropertyChanged;
                if (handler != null) handler(
                    this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
