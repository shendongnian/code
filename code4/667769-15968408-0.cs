    public class TestViewModel : ObservableObject
    {
        public TestViewModel()
        {
            this.MyCommand = new RelayCommand<int>(i => Debug.WriteLine(i));
        }
        public RelayCommand<int> MyCommand { get; private set; }
    }
