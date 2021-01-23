    public interface IProblem<T>
    {
        T Response { get; set; }
        bool IsCorrect();
    }
