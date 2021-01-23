    abstract class BaseDialogVM : BaseVM
    {
        private Visibility _OkButtonVisibility;
        public Visibility OkButtonVisibility {
            get { return _OkButtonVisibility; }
            set { 
               _OkButtonVisibility = value;
               RaisePropertyChanged("OkButtonVisibility");
            }
        }
        private Visibility _CancelButtonVisibility;
        public Visibility CancelButtonVisibility {
            get { return _CancelButtonVisibility; }
            set { 
               _CancelButtonVisibility = value;
               RaisePropertyChanged("CancelButtonVisibility");
            }
        }
    }
    class VM1 : BaseDialogVM { /*...*/ }
