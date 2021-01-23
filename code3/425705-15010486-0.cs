    public abstract class Saver<TSaver, TData>
        where TSaver : Saver<TSaver, TData>
        where TData : ISaveable<TData, TSaver>
    { ... }
    public interface ISaveable<TData, TSaver>
        where TData : ISaveable<TData, TSaver>
        where TSaver : Saver<TSaver, TData>
    { ... }
    public class WorkspaceWindow : ScalingWindow, ISaveable<WorkspaceWindow, WorkspaceWindowSaver>
    { ... }
    public class WorkspaceWindowSaver : Saver<WorkspaceWindowSaver, WorkspaceWindow>
    { ... }
