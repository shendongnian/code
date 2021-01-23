    public class Matcher
    {
        private readonly Result result; // pass this in
        private readonly List<Func<Result, bool>> cases = new ...();
        public Matcher Case<T>(Action<T> action)
        {
            cases.add(result =>
            {
                if(typeof(T).IsAssignableFrom(result.Value.GetType()))
                {
                    action((T)(result.Value));
                    return true;
                }
                return false;
            }
            return this;
        }
        public void Do()
        {
            for each(var @case in cases)
            {
                if(@case(result)) return;
            }
        }
    }
