    class EmptyFilter : TestFilter
    {
        public override bool Match(ITest test)
        {
            return true;
        }
    }
