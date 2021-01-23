    public interface ISmallEmployee
    {
        string attr1 {get;set;} //same as BigEmployee attr1
        string attr2 {get;set;} //same as BigEmployee attr2
        string attr3 {get;set;} //same as BigEmployee attr3
    }
    public class BigEmployee : ISmallEmployee
    {
        ...
    }
