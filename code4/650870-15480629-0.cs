    public class ViewModel
    {
        private bool _caseSensitive;
        public bool CaseSensitive
        {
            get { return _caseSensitive; }
            set
            {
                _caseSensitive = value;
                NotifyPropertyChange(() => CaseSensitive);
                Settings.Default.bSearchCaseSensitive = value;
            }
        }
    }
