    [ClassInterface(ClassInterfaceType.None)]
    ...
    [Entity]  // instead of IEntity marker interface
    public class AQSEntity : IAQSEntity
    {
        public string RecoveryDbName { get; }
    }
    
    [Guid("...")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IAQSEntity // no base interface IEntity!
    {
        string RecoveryDbName { get; }        
    }
