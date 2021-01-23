     [ServiceContract(Namespace = "http://UE.Samples")]
        public interface ICalculator
        {
            [OperationContract]
            double Add(double n1, double n2);
        }
    
        // Service class which implements the service contract.
        public class CalculatorService : ICalculator
        {
            public double Add(double n1, double n2)
            {
                return n1 + n2;
            }
