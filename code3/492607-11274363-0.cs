    [ServiceContract]
    [ServiceKnownType(typeof(SummarySectionFormatA))]
    [ServiceKnownType(typeof(DataSectionFormatA))]
    public interface IService {}
    
    public class Service : IService {}
