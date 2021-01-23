    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<QuestionViewModel> QuestionViewModels { get; set; }
        public MainWindowViewModel()
        {
            QuestionViewModels = new ObservableCollection<QuestionViewModel>
            {
                new GenericQuestionViewModel(),
                new GeographyQuestionViewModel(),
                new BiologyQuestionViewModel()
            };
        }
    }
