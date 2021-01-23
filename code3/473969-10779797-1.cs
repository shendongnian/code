    class Program
    {
        static void Main(string[] args)
        {
            IEnd builder = new StepBuilder()
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
        public IStep1 Initialize()
        {
            return this;
        }
        public IStep2 IStep1.LoadStuff()
        {
            return this; 
        }
        public IStep3 IStep2.Validate()
        {
            return this;
        }
        public IEnd IStep3.End()
        {
            return this;
        }
        public bool IEnd.Save()
        {
            return true;
        }
    }
