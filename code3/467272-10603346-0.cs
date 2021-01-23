    [DataContract]
    [KnownType(typeof(client))]
    public class Contact
    {
       ...
    }
    [ServiceContract]
    [ServiceKnownType(typeof(client))]
    public interface IMyService
    {
        contact getcontact(Guid id);
    }
