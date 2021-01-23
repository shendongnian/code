    public class ViewModel : INotifyPropertyChanged
    {
        private string filterText;
        private Predicate<object> filter;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Foo> Foos { get; } = new ObservableCollection<Foo>();
        public string FilterText
        {
            get { return this.filterText; }
            set
            {
                if (value == this.filterText) return;
                this.filterText = value;
                this.OnPropertyChanged();
                this.Filter = string.IsNullOrEmpty(this.filterText) ? (Predicate<object>)null : this.IsMatch;
            }
        }
        public Predicate<object> Filter
        {
            get { return this.filter; }
            private set
            {
                this.filter = value;
                this.OnPropertyChanged();
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool IsMatch(object item)
        {
            return IsMatch((Foo)item, this.filterText);
        }
        private static bool IsMatch(Foo item, string filterText)
        {
            if (string.IsNullOrEmpty(filterText))
            {
                return true;
            }
            var name = item.Name;
            if (filterText.Length == 1)
            {
                return name.StartsWith(filterText, StringComparison.OrdinalIgnoreCase);
            }
            return name.IndexOf(filterText, 0, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
