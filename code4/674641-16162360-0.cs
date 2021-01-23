    public interface IDescriptionValue
    {
    public string Description {get;set;}
    public string Value {get;set;}
    }
    
    public class CustomClass1 : IDescriptionValue{
    public string Description {get;set;}
    public string Value {get;set;}
    }
    //snip...
    public class CustomClass4 : IDescriptionValue{
    public string Description {get;set;}
    public string Value {get;set;}
    }
    //accepts parameters of type IDescriptionValue
    public void setDropdownData(IDescriptionValue inputData){
    // your code here
    }
