    public class SimpleExecute : IExecute<int>   
    {   
       public List<int> Execute()   
       { return a list of ints... }   
       IList IExecute.Execute() { return this.Execute(); }
    }
