    [DataContract]
    [KnownType(typeof(Client))]
    public class Contact
    {
       ...
    }
    [ServiceContract]
    [ServiceKnownType(typeof(Client))]
    public interface IMyService
    {
        contact getcontact(Guid id);
    }
