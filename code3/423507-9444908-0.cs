    public interface IStep
    {
        bool IsValid { get; }
        void Save();
    }
    public class BeginStep : IStep
    {
        public bool IsValid
        {
            get
            {
                return PerformCheck1();
            }
        }
        public void Save()
        {
            DoThing1();
        }
    }
    public class EndStep : IStep
    {
        public bool IsValid
        {
            get
            {
                // Skipped PerformCheck2() since the result is directly overwritten
                return PerformCheck3();
            }
        }
 
        public void Save()
        {
            DoThing2();
            DoThing3();
            DoThing4();
        }
    }
