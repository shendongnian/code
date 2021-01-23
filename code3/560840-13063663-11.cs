            namespace WpfApplication1
            {
                public class RBVM : INotifyPropertyChanged
                {
                    public RBVM()
                    {
                        _rb = new RB();
                    }
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
                    public bool BaseCheck
                    {
                        get
                        {
                            return RB.BaseCheck;
                        }
                        set
                        {
                            RB.BaseCheck = value;
                            RaisePropertyChanged("BaseCheck");
                        }
                    }
                    public string RadioBase
                    {
                        get
                        {
                            return RB.RadioBase;
                        }
                        set
                        {
                            RB.RadioBase = value;
                            RaisePropertyChanged("RadioBase");
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
