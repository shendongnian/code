    public interface IOperation<out T, out R>
        where T : class, IParameter
        where R : class, IResult
    {
        Type ParameterType { get; }
    
        Type ResultType { get; }
    
        T Parameter { get; /*set;*/ } //can't allow the interface to set T 
    
        // R Execute(T parameter); // can't have an Execute with T as a parameter
        R Execute(); // you can however inject T in the constructor of the
                     // inherited class and call Execute without parameters    
    }
