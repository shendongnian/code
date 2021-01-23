    public abstract class FooBase
    {
        public void DoSomething()
        {
            DoUnconditionalActions();
            if (someCondition)
            {
                DoConditionalAction();
            }
        }
        protected abstract void DoConditionalAction();
    }
