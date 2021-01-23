    public class MyTab : ViewModelBase
    {
        #region Declarations
        private ObservableCollection<string> statusList;
        private string selectedStatus;
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>The header.</value>
        public string Header { get; set; }
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string Content { get; set; }
        /// <summary>
        /// Gets or sets the status list.
        /// </summary>
        /// <value>The status list.</value>
        public ObservableCollection<string> StatusList
        {
            get
            {
                return statusList;
            }
            set
            {
                statusList = value;
                NotifyPropertyChanged("StatusList");
            }
        }
        /// <summary>
        /// Gets or sets the selected status.
        /// </summary>
        /// <value>The selected status.</value>
        public string SelectedStatus
        {
            get
            {
                return selectedStatus;
            }
            set
            {
                selectedStatus = value;
                NotifyPropertyChanged("SelectedStatus");
            }
        }
        #endregion
    }
