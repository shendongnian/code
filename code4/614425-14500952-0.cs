        public class MyViewModel : INotifyPropertyChanged
        {
            private string someText;
            public string SomeText
            {
                get
                {
                    return this.someText;
                }
                set
                {
                    this.someText = value;
                    if (SomeCondition(this.someText))
                    {
                        this.someText = string.Empty;
                    }
                    var epc = this.PropertyChanged;
                    if (epc != null)
                    {
                        epc(this, new PropertyChangedEventArgs("SomeText"));
                    }
                }
            }
        }
