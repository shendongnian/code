    public class AnswersModelValidator : AbstractValidator<AnswersModel> {
        public AnswersModelValidator() {
            RuleFor(x => x.Answers).SetCollectionValidator(new AnswerValidator());
        }
    }
    
    public class AnswersModel
    {
        public List<Answer> Answers{get;set;}
    }
