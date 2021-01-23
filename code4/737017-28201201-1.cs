     #region DataBind
        public class FileListViewItem : INotifyPropertyChanged
        {
            public string ui_visiable { get; set; }
            public string ui_complete_percentage { get; set; }
            public string ui_incomplete_percentage { get; set; }
            public string ui_complete_color { get; set; }
            public string ui_incomplete_color { get; set; }
            private string _ui_tip_text;
            public string ui_tip_text
            {
                get { return _ui_tip_text; }
                set
                {
                    _ui_tip_text = value;
                    RaisePropertyChanged("ui_tip_text");
                }
            }
    
            #region Implement INotifyPropertyChanged
            public event PropertyChangedEventHandler PropertyChanged;
            public void RaisePropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
        ObservableCollection<FileListViewItem> FileListViewItemGroup = new ObservableCollection<FileListViewItem>();
        public void Bind() {
            lstFileManager.ItemsSource = FileListViewItemGroup;
        }
        #endregion
