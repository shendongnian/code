    public interface IProblem<T> : IProblem
    {
        T Response { get; set; }
        bool IsCorrect();
    }
