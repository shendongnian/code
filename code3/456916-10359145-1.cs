    public class QuestionsWithAnswersController : Controller
    {
        public ActionResult Index()
        {
            //TODO: fetch from the repository instead of hardcoding
            QuestionsWithAnswersViewModel model = new QuestionsWithAnswersViewModel()
            {
                QuestionsWithAnswers = new[]
                {
                    new QuestionWithAnswer() { Id = 1, Question = "How are you?" },
                    new QuestionWithAnswer() { Id = 2, Question = "Why is the sky blue?" },
                }
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(QuestionsWithAnswersViewModel model)
        {
            //the model will be properly bound here
            return View(model);
        }
    }
