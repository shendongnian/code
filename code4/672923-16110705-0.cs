    /// <summary>
    /// Description
    /// </summary>
    /// <typeparam name="T">The type of xxxx</typeparam>
    /// <typeparam name="T2">The type of xxxx</typeparam>
    public interface ICommand<in T, in T2>
    {
      void Execute(T arg1, T2 arg2);
    }
