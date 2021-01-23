    public class CustomInterfaceImplementor: ICustomInterface
    {
         public int Property1 {get;set;}
    }
            
    [DataContract]
    public class MyClass
    {
         [DataMember(Name="_myInterface")]
         private CustomInterfaceImplementor _MyInterface;
         public ICustomInterface MyInterface
         {
              get {return (_MyInterface as ICustomInterface);}
              set {_MyInterface = (value as CustomInterfaceImplementor);}
         }
    }
