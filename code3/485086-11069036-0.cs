    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ItemDeEmbarqueViewModel> _itensDoEmbarque;
        private EmbarqueViewModel _embarqueAtual;
     
        public ViewModel()
        {
            ItensDoEmbarque = new ObservableCollection<ItemDeEmbarqueViewModel>();
        }
     
        public event PropertyChangedEventHandler PropertyChanged;
     
        public ObservableCollection<ItemDeEmbarqueViewModel> ItensDoEmbarque
        {
            get { return _itensDoEmbarque; }
            set
            {
                _itensDoEmbarque= value;
                OnPropertyChanged("ItensDoEmbarque");
            }
        }
    
        public EmbarqueViewModel EmbarqueAtual
        {
            get { return _embarqueAtual; }
            set
            {
                _embarqueAtual = value;
                OnPropertyChanged("EmbarqueAtual");
            }
        }
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
