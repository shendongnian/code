    public interface IExclusiveCommand : IBaseCommand
    {
        void ExclusiveMethod();  //Not necessary if there are no differences between Base and Exclusive
    }
    public class ProtocolEncapsulator<TContainedCommand> : IBaseCommand where TContainedCommand : IExclusiveCommand
    {
    }
