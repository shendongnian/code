    public class MultiPageViewModel
    {
        public Page1ViewModel Page1 { get; set; }
        public Page2ViewModel Page2 { get; set; }
        public MultiPageViewModel()
        {
            Page1 = new Page1ViewModel();
            Page2 = new Page2ViewModel();
            Page2.AddNewCommand = new Command(Page1.AddCommand);
        }
    }
