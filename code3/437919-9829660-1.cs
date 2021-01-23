    public class AddressException : Exception
    {
     public string InputData { get; set; }
     public AddressException(string message, string inputData) : base(message)
     {
       InputData = inputData;
     }
    }
