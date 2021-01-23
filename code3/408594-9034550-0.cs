    public interface IExecutionSettings
    {
        IExecutionParameter this[string key] { get; }
    }
    public interface IDesignerSettings
    {
        IDesignerParameter this[string key] { get; }
    }
