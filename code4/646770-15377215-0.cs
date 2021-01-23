    public interface ITask
    {
        void Execute();
    }
    public interface IAuthenticateTask : ITask {}
    public interface IResetPasswordTask : ITask {}
