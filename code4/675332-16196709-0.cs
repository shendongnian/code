    class Program
        {
            static void Main(string[] args)
            {
                var transferenceInfo = new InterbankTranferenceInfo();
    
                var orchestrator = new Orchestrator(new InternalDebitOperation(transferenceInfo),
                                                    new InterbankCreditOperation(),
                                                    new CommissionOperation());
    
                orchestrator.Run();
            }
        }
    
        public class InterbankTranferenceInfo : IParameter
        {
            public bool InternalDebitDone { get; set; }
    
            public bool InterbankCreditDone { get; set; }
    
            public bool CommissionDone { get; set; }
        }
    
        public class InternalDebitOperation : Operation<InterbankTranferenceInfo>, IOperation<InterbankTranferenceInfo>
        {
            public InternalDebitOperation(InterbankTranferenceInfo parameter)
                : base(parameter)
            {
            }
    
            public override InterbankTranferenceInfo Execute()
            {
                return new InterbankTranferenceInfo() { InternalDebitDone = true };
            }
        }
    
        public class InterbankCreditOperation : Operation<InterbankTranferenceInfo>, IOperation<InterbankTranferenceInfo>
        {
            public override InterbankTranferenceInfo Execute()
            {
                Parameter.InterbankCreditDone = true;
    
                return Parameter;
            }
        }
    
        public class CommissionOperation : Operation<InterbankTranferenceInfo>, IReversible, IOperation<InterbankTranferenceInfo>
        {
            public override InterbankTranferenceInfo Execute()
            {
                Parameter.CommissionDone = true;
    
                // Uncomment this code to test Reverse operation.
                // throw new Exception("Test exception, it should trigger Reverse() method.");
    
                return Parameter;
            }
    
            public void Reverse()
            {
                Parameter.CommissionDone = false;
            }
        }
    
        public enum OperationStatus
        {
            Done,
            Pending,
            Reversed
        }
    
        public interface IParameter
        {
        }
    
        public interface IReversible
        {
            void Reverse();
        }
        
        public interface IOperation<out T> : IInternalOperation<T>  where T : IParameter
        {
        }
    
        public interface IInternalOperation<out T> : IExecutableOperation<T>
        {
            bool GetParameterFromParentOperation { get; }
    
            OperationStatus Status { get; set; }
            
            IParameter Execute(IParameter parameter);      
        }
    
        public interface IExecutableOperation<out T>
        {
            T Execute();
        }
    
        //[System.Diagnostics.DebuggerStepThroughAttribute()]
        public abstract class Operation<T> : IInternalOperation<T> where T : IParameter
        {
            public T Parameter { get; private set; }
    
            public bool GetParameterFromParentOperation { get { return this.Parameter == null; } }
    
            public OperationStatus Status { get; set; }
    
            public Operation()
            {
                Status = OperationStatus.Pending;
            }
    
            public Operation(IParameter parameter)
            {
                Status = OperationStatus.Pending;
                this.Parameter = (T)parameter;
            }
    
            public abstract T Execute();
    
            public virtual IParameter Execute(IParameter parameter)
            {
                this.Parameter = (T)parameter;
                return this.Execute();
            }
        }
    
        public class Orchestrator
        {
            public List<IOperation<IParameter>> Operations { get; private set; }
    
            public Orchestrator(params object[] operations) 
            {
                this.Operations = new List<IOperation<IParameter>>();
    
                foreach (var item in operations)
                {
                    this.Operations.Add((IOperation<IParameter>)item);
                }
            }
    
            public IParameter Run()
            {
                IParameter previousOperationResult = null;
    
                foreach (var operation in this.Operations)
                {
                    try
                    {
                        if (operation.GetParameterFromParentOperation)
                            previousOperationResult = operation.Execute(previousOperationResult);
                        else
                            previousOperationResult = operation.Execute();
    
                        operation.Status = OperationStatus.Done;
                    }
                    catch (Exception)
                    {
                        foreach (var o in this.Operations)
                        {
                            if (o is IReversible)
                            {
                                ((IReversible)o).Reverse();
                                o.Status = OperationStatus.Reversed;
                            }
                            else
                                throw;
                        }
                        break;
                    }
                }
    
                return previousOperationResult;
            }
        }
