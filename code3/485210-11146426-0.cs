    using System;
    using System.Windows.Input;
    using Setup.Common;
    
    namespace ExampleOfButtonList
    {
        public class ButtonViewModel : ViewModelBase
        {
            #region Member fields
            protected bool _IsVisible;
            protected bool _IsEnabled;
            protected RelayCommand _ButtonCommand;
            protected String _Text;
            #endregion
    
            #region Constructors
            /// <summary>
            /// The default constructor
            /// </summary>
            public ButtonViewModel()
            {
            }
            #endregion
    
            #region Properties
            public virtual ICommand ButtonCommand
            {
                get { return _ButtonCommand; }
                set
                {
                    _ButtonCommand = value as RelayCommand;
                    NotifyPropertyChanged("ButtonCommand");
                }
            }
    
            public bool IsVisible
            {
                get { return _IsVisible; }
                set
                {
                    _IsVisible = value;
                    NotifyPropertyChanged("IsVisible");
                }
            }
    
            public String Text
            {
                get { return _Text; }
                set
                {
                    _Text = value;
                    NotifyPropertyChanged("Text");
                }
            }
            #endregion
        }
    }
