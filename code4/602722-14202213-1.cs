    public sealed class MyViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<LightItem> _items = new ObservableCollection<LightItem>();
        private LightItem _selectedItem;
        private ExtraInformation _extraStuff;
        public MyViewModel()
        {
            this._items.Add(new LightItem("Tim", "Dish Washer"));
            this._items.Add(new LightItem("Bob", "Window Washer"));
            this._items.Add(new LightItem("Jill", "Widget Washer"));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ExtraInformation ExtraStuff
        {
            get { return this._extraStuff; }
            private set
            {
                this._extraStuff = value;
                this.OnPropertyChanged("ExtraStuff");
            }
        }
        public ReadOnlyObservableCollection<LightItem> Items { get { return new ReadOnlyObservableCollection<LightItem>(this._items); } }
        public LightItem SelectedItem
        {
            get { return this._selectedItem; }
            set
            {
                this._selectedItem = value;
                this.OnPropertyChanged("SelectedItem");
                this.ExtraStuff = new ExtraInformation(value);
            }
        }
        private void OnPropertyChanged(string name)
        {
            if (null != this.PropertyChanged)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public sealed class ExtraInformation
        {
            private readonly double _extraDoubleField;
            private readonly int _extraIntegerField;
            public ExtraInformation(LightItem light)
            {
                // you could get more info for your record from the db
                // but here we just get some random numbers
                var rnd = new Random();
                this._extraDoubleField = rnd.NextDouble();
                this._extraIntegerField = rnd.Next();
            }
            public double ExtraDoubleField { get { return this._extraDoubleField; } }
            public double ExtraIntegerField { get { return this._extraIntegerField; } }
        }
        public sealed class LightItem
        {
            private readonly string _job;
            private readonly string _name;
            public LightItem(string name, string job)
            {
                this._name = name;
                this._job = job;
            }
            public string Job { get { return this._job; } }
            public string Name { get { return this._name; } }
        }
    }
