        namespace WpfApplication1
        {
            public class RBViewModel : INotifyPropertyChanged
            {
               private  ObservableCollection<RB> _rbs = new ObservableCollection<RB>();
               private RB _rb;
                public RB RB
               {
                   get
                   {
                       return _rb;
                   }
                   set
                   {
                       _rb = value;
                   }
               }
       
        
                public ObservableCollection<RB> Rbs
               {
                   get
                   {
                       return _rbs;
                   }
                   set
                   {
                       _rbs = value;
                   }
               }
                public event PropertyChangedEventHandler PropertyChanged;
                #region Methods
                private void RaisePropertyChanged(string propertyName)
                {
                    PropertyChangedEventHandler handler = PropertyChanged;
                    if (handler != null)
                    {
                        handler(this, new PropertyChangedEventArgs(propertyName));
                    }
                }
                #endregion
            }
        }
