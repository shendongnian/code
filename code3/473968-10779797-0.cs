    class Program
    {
        static void Main(string[] args)
        {
            IEnd builder = StepBuilder
                .Initialize()
                .LoadStuff()
                .Validate()
                .End();
        }
    }
    public class StepBuilder : IInitialize,
                                 IStep1,
                                 IStep2,
                                 IStep3,
                                 IEnd
    {
        private StepBuilder()
        {
        }
        public static IStep1 Initialize()
        {
            var builder = new StepBuilder();
            //do initialisation stuff
            return builder;
        }
        public IStep2 LoadStuff()
        {
            return this; 
        }
        public IStep3 Validate()
        {
            return this;
        }
        public IEnd End()
        {
            return this;
        }
        public bool Save()
        {
            return true;
        }
    }
