    [Serializable]
    public class SerializeExample
    {
        public string ResultType { get; set; }
        public string Error { get; set; }
        public string Failure { get; set; }
        public List<string> Steps { get; set; }
        public bool ShouldSerializeError()
        {
            return "Error".Equals(ResultType);
        }
        public bool ShouldSerializeFailure()
        {
            return "Failure".Equals(ResultType);
        }
        public bool ShouldSerializeSteps()
        {
            return ShouldSerializeError() || ShouldSerializeFailure();
        }
    }
