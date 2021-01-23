    public interface IProgressable
    {
        float Progress { get; }
        bool IsDone { get; }
    }
    public interface ICancelable
    {
        bool Canceled { get; }
    }
