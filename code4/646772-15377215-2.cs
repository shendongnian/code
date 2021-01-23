    public interface ITask<TInput>
    {
       void Execute(TInput input);
    }
    public interface IOutputTask<TOutput>
    {
       TOutput Execute();
    }
 
    public interface IOutputTask<TOutput, TInput>
    {
       TOutput Execute(TInput input);
    }
