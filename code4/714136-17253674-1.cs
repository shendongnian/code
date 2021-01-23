        public class Carrello :INotifyPropertyChanged
        {
            private string _id_prodotto;
            public string ID_prodotto
            {
                get { return _id_prodotto; }
                set
                {
                    if (value != _id_prodotto)
                    {
                        _id_prodotto = value;
                        OnPropertyChanged("ID_prodotto");
                    }
                }
            }
    //
    //      Do the same thing for all the other public properties you are binding to
    //
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = System.Threading.Interlocked.CompareExchange(ref 
                                 PropertyChanged, null, null);
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }
