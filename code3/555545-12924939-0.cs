    namespace GettingStartedHost
    {
        // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
        public class Service1 : IService1
        {
            public string GetData(int value)
            {
                return string.Format("You entered: {0}", value);
            }
    
            public int GetProduct(int a, int b)
            {
                return a * b;
            }
    
            public CompositeType GetDataUsingDataContract(CompositeType composite)
            {
                if (composite == null)
                {
                    throw new ArgumentNullException("composite");
                }
                if (composite.BoolValue)
                {
                    composite.StringValue += "Suffix";
                }
                return composite;
            }
        }
    
        [ServiceContract]
        public interface IService1
        {
            [OperationContract]
            int GetProduct(int a, int b);
    
            [OperationContract]
            string GetData(int value);
    
            [OperationContract]
            CompositeType GetDataUsingDataContract(CompositeType composite);
        }
    }
