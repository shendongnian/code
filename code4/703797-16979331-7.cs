    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.ComponentModel;
    namespace WpfCommandControl
    {
        public partial class CommandControl : UserControl, INotifyPropertyChanged
        {
        #region [ Private Members ]
        private bool _canActivated = false;
        private int _counter = 0;
        CommandImplementation _activateCommand;
        #endregion
        #region [ Properties ]
        public int CommandCounter
        {
            get
            {
                return _counter;
            }
            set
            {
                _counter = value;
                OnNotifyPropertyChanged("CommandCounter");
            }
        
        }
        public bool CanActivated
        {
            get
            {
                return _canActivated;
            }
            set
            {
                _canActivated = value;
                OnNotifyPropertyChanged("CanActivated");
            }        
        }
        #endregion
        #region [ Property_Changed_Utilities ]
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnNotifyPropertyChanged(String info)
        {
            // Note: Do not forget to add interface "INotifyPropertyChanged" to your class.
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
        # region [ Commands ]
        public ICommand ActivateCommand
        {
            get
            {
                return _activateCommand;
            }
        }
        #endregion
        #region [ Constructor ]
        public CommandControl()
        {
            InitializeComponent();
            _activateCommand = new CommandImplementation(param => this.Activate(), param => this.CanActivated);
        }
        #endregion
        #region [ Methods ]
        void Activate()
        {
            CommandCounter++;
        }
        #endregion
    }
    }
