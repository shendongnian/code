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
        public override string ToString()
        {
            return ID_prodotto;
        }
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
