    abstract class Rule<T>
    {
        protected abstract bool implementRule(T on, GameWorld gw);
        protected abstract void doIfTrue();
        protected abstract void doIfFalse();
        public void runRule(T on, GameWorld gw)
        {
            if (implementRule(on, gw))
            {
                doIfTrue();
            }
            else
            {
                doIfFalse();
            }
        }
    }
