         [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
        [System.ServiceModel.ServiceContractAttribute(ConfigurationName=
        "ServiceRef.IService1")]
      public interface IService1
       {
           [System.ServiceModel.OperationContractAttribute(
           Action="http://tempuri.org/Service1/AddNumber",
           ReplyAction="http://tempuri.org/IHelloWorld/IntegersResponse")]                   
           int Display(int a,int b)
           [System.ServiceModel.OperationContractAttribute(
           Action="http://tempuri.org/IHelloWorld/ConcatenateStrings",
           ReplyAction="http://tempuri.org/Service1/DoublesResponse")]
           double Display(double a,double b)
      }
