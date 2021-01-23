    [ServiceContract]
    public interface IRandomNumberService
    {
        [OperationContract]
        int GetRandomNumber();
    }
    
    public class RandomNumberService : IRandomNumberService
    {
        public int GetRandomNumber()
        {
            return Program.CurrentRandomNumber; // Well ... you get the idea. ;)
        }
    }
