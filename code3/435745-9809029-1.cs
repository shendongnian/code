    namespace FavUrl.viewmodels
    {
        public class MainPageViewModel : ViewModelBase
        {
            public ObservableCollection<string> Urls {
                get { return (App.Current as App).Urls; }
            }
        }
    }
