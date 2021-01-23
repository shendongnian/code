    public class MainWindowViewModel : ViewModelBase
    {
        public QuestionViewModel QuestionViewModel { get; set; }
        public MainWindowViewModel()
        {
            QuestionViewModel = new BiologyQuestionViewModel();
        }
    }
