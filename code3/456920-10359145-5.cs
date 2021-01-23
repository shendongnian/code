    public class AnswersController : Controller
    {
        QuestionRepository _questionRepository = new QuestionRepository();
        public ActionResult Index()
        {
            AnswersViewModel model = new AnswersViewModel();
            model.Answers = new List<Answer>();
            IEnumerable<Question> questions = _questionRepository.GetRandomQuestions();
            foreach (Question question in questions)
            {
                model.Answers.Add(new Answer() { QuestionText = question.QuestionText });
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(AnswersViewModel model)
        {
            //the model will be properly bound here
            return View(model);
        }
    }
