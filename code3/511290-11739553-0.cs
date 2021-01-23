    // Multiple allows concurrent processing of multiple messages by a service instance.
    // The service implementation should be thread-safe. This can be used to increase throughput.
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    
    // Uses Thread.Sleep to vary the execution time of each operation.
    public class CalculatorService : ICalculatorConcurrency
    {
        int operationCount;
    
        public double Add(double n1, double n2)
        {
            operationCount++;
            System.Threading.Thread.Sleep(180);
            return n1 + n2;
        }
    
        public double Subtract(double n1, double n2)
        {
            operationCount++;
            System.Threading.Thread.Sleep(100);
            return n1 - n2;
        }
    
        public double Multiply(double n1, double n2)
        {
            operationCount++;
            System.Threading.Thread.Sleep(150);
            return n1 * n2;
        }
    
        public double Divide(double n1, double n2)
        {
            operationCount++;
            System.Threading.Thread.Sleep(120);
            return n1 / n2;
        }
    
        public string GetConcurrencyMode()
        {   
            // Return the ConcurrencyMode of the service.
            ServiceHost host = (ServiceHost)OperationContext.Current.Host;
            ServiceBehaviorAttribute behavior = host.Description.Behaviors.Find<ServiceBehaviorAttribute>();
            return behavior.ConcurrencyMode.ToString();
        }
    
        public int GetOperationCount()
        {   
            // Return the number of operations.
            return operationCount;
        }
    }
