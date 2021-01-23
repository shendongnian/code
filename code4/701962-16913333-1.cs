        public class ViewModel : INotifyPropertyChanged
        {
            #region INotifyPropertyChanged Implementation
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected void InvokePropertyChanged(string propertyName)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                if (PropertyChanged != null) PropertyChanged(this, e);
            }
    
            #endregion
    
            public ViewModel()
            {
                this.FooBars.Add(new FooBar()
                {
                    B = new Bar(){Y = 30},
                    F = new Foo(){ X = 100}
                });
            }
    
            private ObservableCollection<FooBar> fooBars = new ObservableCollection<FooBar>();
            public ObservableCollection<FooBar> FooBars
            {
                get { return this.fooBars; }
                set
                {
                    this.fooBars = value;
                    InvokePropertyChanged("FooBars");
                }
            }
        }
