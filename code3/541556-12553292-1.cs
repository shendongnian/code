    public interface ITransaction<T> where T : IResponse
    {
        bool Validate(out T theResponse);
    }
    
    public class TransactionDerived : ITransaction<ResponseDerived>
    {
        public bool Validate(out ResponseDerived theResponse)
        {
    
            theResponse = new ResponseDerived();
            theResponse.message = "My message";
            return true;
        }
    
        public void Execute()
        {
            ResponseDerived myResponse = new ResponseDerived();
    
            if (Validate(out myResponse))
                Console.WriteLine(myResponse.message);
        }
    }
