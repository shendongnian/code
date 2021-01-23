    public class ViewModel
    {
        public bool IsChecked { get; set; }
        public bool IsClicked { get; set; }
        public ICommand CalibrateCommand { get; set; }
        public ViewModel()
        {
            CalibrateCommand = new CalibrateCommand(this);
        }
    }
