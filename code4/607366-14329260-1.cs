    public interface ILook
    {
        Boolean IsNice { get; }
        Boolean IsPretty { get; }
    }
    public struct ExampleStructA : ILook { }
    public Boolean IsWhat(ILook tiVerify, CheckType type)
    {
        switch (type)
        {
            case CheckType.Pretty: 
               return toVerify.IsPretty;
            
             // And so on...
        }    
    }
