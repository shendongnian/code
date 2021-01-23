    public class TransactionDerived : ITransaction
    {
        public bool Validate(out IResponse theResponse)
        {    
            theResponse = new ResponseDerived();
            ((ResponseDerived)theResponse).message = "My message";
            return true;
        }
    
        public void Execute()
        {
            IResponse myResponse;
    
            if (Validate(out myResponse))
                Console.WriteLine(((ResponseDerived)myResponse).message);
        }
    }
