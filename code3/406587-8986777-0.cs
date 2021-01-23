    public interface IInHeaderType
    {
     string CompanyId { get; set; }
     string UserId { get; set; }
     string Password { get; set; }
     string MessageId { get; set; }
    }
    public static T GetInHeaderProperty<T>() where T : IInHeaderType, new ()
    {
            T value = new T();
            // fill the properties of object and return the instance of T
            // I will call it when I need x.InHeaderType or y.InHeaderType
    }
