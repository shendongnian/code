    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Application localized strings
        /// </summary>
        public AppResources Loc
        {
            get { return _loc ?? (_loc = new AppResources()); }
        }
        private AppResources _loc;
        ...
    }
