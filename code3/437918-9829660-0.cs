    public class AddressException
    {
     public string InputData { get; set; }
     public AddressException(string message, string inputData) : base(message)
     {
       InputData = inputData;
     }
    }
