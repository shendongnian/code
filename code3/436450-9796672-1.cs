    public interface IAnyPublic { Guid user; }
    public interface IAnyPrivate { AuthenticationTicket ticket; }
    public interface IOneBase { int foo; string goo; }
    public interface IOnePublic : IOneBase, IAnyPublic { } // nothing to add, sir!
    public interface IOnePrivate : IOneBase, IAnyPrivate { } // nothing to add, sir!
    public class OneBase : IOnePublic, IOnePrivate { /*implement*/ }
