    public class SomeClass : IContract, IContract<SomeContractClass>
    {
        // Method of IContract<SomeContractClass>
        public void Definition(SomeContractClass data)
        {
            Console.WriteLine("Processing a SomeContractClass instance");            
            // ...etc
        }
        // Method of IContract hence of IContract<object>
        void IContract<object>.Definition(object data)
        {
            if (data is SomeContractClass)
              this.Definition(data as SomeContractClass);
            else
            {
              string descriptor = (null == data) 
                ? "A null reference" 
                : "An instance of " + data.GetType().Name";
              Console.WriteLine("Processing something other than a SomeContractClass instance: " + descriptor);
              // ...etc
            }
        }
       
    }
