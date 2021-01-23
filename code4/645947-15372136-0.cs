    public class MainWindowViewModel : ReactiveObject
    {
        private ReactiveObject _CurrentControlViewModel = new HomePageViewModel();
        public ReactiveObject CurrentControlViewModel {
            get { return _CurrentControl; }
            set { this.RaiseAndSetIfChanged(x => x.CurrentControlViewModel, value); }
        }
    }
