    public class ClassA
    {
        private readonly Func<string, IClassB> myFunc;
        public ClassA(Func<string, IClassB> myFunc)
        {
            this.myFunc = myFunc;
        }
        public IClassB MyFunc(string input)
        {
            if (this.myFunc = null)
            {
                return null;
            }
            return this.myFunc(input);
        }
    }
