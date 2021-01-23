    <system.serviceModel>
         …
        <bindings>
          <basicHttpBinding>
            <binding name="ExampleBinding" transferMode="Streaming"/>
          </basicHttpBinding>
        </bindings>
         …
    <system.serviceModel>
    
    [ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
    public interface IStreamedService
    {
        [OperationContract]
        Stream Echo(Stream data);
        [OperationContract]
        Stream RequestInfo(string query);
        [OperationContract(OneWay=true)]
        void ProvideInfo(Stream data);
    }
