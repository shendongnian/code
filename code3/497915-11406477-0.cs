    public interface IService
    {
        IEnumerable<Problem> GetProblems();
        void Submit(IEnumerable<Problem>);
    }
