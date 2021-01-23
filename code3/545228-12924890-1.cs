    public interface IAddIn<T> where T : IAddInInfo
    {
        T Info { get; }
        //Continue with the rest of the members you would want every add-in to have.
    }
