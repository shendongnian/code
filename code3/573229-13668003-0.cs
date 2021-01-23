    public interface ITypeA{
       int Id {get;set;}
    }
    
    public interface ITypeB{
       int id {get;set;}
    }
    
    public class TypeA:ITypeA
       string Name{get;set;}
       int id {get;set;}
    
       [JsonConverter(typeof (ConcreteTypeConverter<TypeB>))]
       ITypeB type{get;set;}
    }
    
    public class TypeB:ITypeB
    {
       int id {get;set;}
    }
