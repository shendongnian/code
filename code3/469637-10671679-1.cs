    public class LambdaWrapper
    {
        private object param;
        private Delegate compiledLambda;
        public LambdaWrapper(Delegate compiledLambda, object param)
        {
            this.compiledLambda = compiledLambda;
            this.param = param;
        }
        public dynamic Execute()
        {
            return compiledLambda.DynamicInvoke(param);
        }
    }
