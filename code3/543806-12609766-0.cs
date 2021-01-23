    public abstract class ExtImage : UserControl, IRequiredAnswer
    {
        public abstract bool AnswerRequired  { get; }
           
        public abstract void LabelRequiredFieldEmpty ();
    }
