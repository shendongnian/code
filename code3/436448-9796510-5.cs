    public class Dto<T> {
        public T ID { get; set; }
        string property1;
        ...
        string propertyN;
    } 
    var publicDto = new Dto<Guid>();
    var privateDto = new Dto<AuthenticationTicket>();
