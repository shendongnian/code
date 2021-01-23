    public class EvaluateAttribute : Attribute
    {
        private readonly Type[] _accessEvaluators;
        public EvaluateAttribute(params Type[] accessEvaluators)
        {
            _accessEvaluators = accessEvaluators;
        }
    }
