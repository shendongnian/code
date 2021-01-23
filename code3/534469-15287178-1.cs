    public class MainViewModel : ViewModelBase
    {
        #region Declarations
        private bool isNoChecked;
        private bool isYesChecked;
        private ICommand checkNoCommand;
        private ICommand checkYesCommand;
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether this instance is no checked.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is no checked; otherwise, <c>false</c>.
        /// </value>
        public bool IsNoChecked
        {
            get
            {
                return isNoChecked;
            }
            set
            {
                isNoChecked = value;
                NotifyPropertyChanged("IsNoChecked");
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is yes checked.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is yes checked; otherwise, <c>false</c>.
        /// </value>
        public bool IsYesChecked
        {
            get
            {
                return isYesChecked;
            }
            set
            {
                isYesChecked = value;
                NotifyPropertyChanged("IsYesChecked");
            }
        }
        #endregion
        #region Commands
        /// <summary>
        /// Gets the check no command.
        /// </summary>
        /// <value>The check no command.</value>
        public ICommand CheckNoCommand
        {
            get
            {
                if (checkNoCommand == null)
                {
                    checkNoCommand = new RelayCommand(param => this.CheckNo(),
                        null);
                }
                return checkNoCommand;
            }
        }
        /// <summary>
        /// Gets the check yes command.
        /// </summary>
        /// <value>The check yes command.</value>
        public ICommand CheckYesCommand
        {
            get
            {
                if (checkYesCommand == null)
                {
                    checkYesCommand = new RelayCommand(param => this.CheckYes(),
                        null);
                }
                return checkYesCommand;
            }
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// Changes the checked.
        /// </summary>
        private void CheckNo()
        {
            this.IsNoChecked = true;
        }
        /// <summary>
        /// Checks the yes.
        /// </summary>
        private void CheckYes()
        {
            this.IsYesChecked = true;
        }
        #endregion
    }
