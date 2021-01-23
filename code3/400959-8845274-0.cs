    public interface IProblemViewModel<T> : IViewModel
    {
        //No reason to use the base here instead of the interface
        IProblem<T> Problem { get; set; }
    }
