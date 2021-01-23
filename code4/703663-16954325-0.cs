    public class AnnualReportWelComeViewModel : IViewModelWithMessage
    {
        public string ViewModelMessage { get; set; }
        ....
        string IViewModelWithMessage.Message {
            get { return ViewModelMessage; }
            set { ViewModelMessage = value; }
        }
    }
