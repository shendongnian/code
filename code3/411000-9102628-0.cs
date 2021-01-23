    public class DoWork()
    {
    
       public enum ExecutionSequence {CallMethod1, CallMethod2, CallBoth};
       public MethodWorkA(List<long> TheList, ExecutionSequence exec) 
       {
           if(exec == ExecutionSequence.CallMethod1) 
             MethodWork1(..);
           else if(exec == ExecutionSequence.CallMethod2)
             MethodWork2(..);
           else if(exec == ExecutionSequence.Both)
           {
              MethodWork1(..);
              MethodWork2(..);
           } 
       }
    
       public void MethodWork1(parameters) {}
    
       public void MethodWork2(parameters) {}
    
    }
