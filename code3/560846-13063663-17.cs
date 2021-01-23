         namespace WpfApplication1
        {
            public class RBViewModel : INotifyPropertyChanged
            {
                public void AddRb(string content, bool isChk) 
                {
                    _rbs.Add(new RBVM() { RadioBase = content, BaseCheck = isChk });
                }
                public void ClearAllValues() {
                    foreach (RBVM item in _rbs)
                    {
                        item.BaseCheck = false;
                    }
                }
                
                
                private ObservableCollection<RBVM> _rbs = new ObservableCollection<RBVM>();
                
                public ObservableCollection<RBVM> Rbs
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
