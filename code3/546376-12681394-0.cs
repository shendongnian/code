    <system.serviceModel>
     <services>
       <service behaviorConfiguration="returnFaults" name="TestService.Service">
          <endpoint binding="wsHttpBinding" bindingConfiguration=
                "TransportSecurity" contract="TestService.IService"/>
          <endpoint address="mex" binding="mexHttpsBinding" 
                name="MetadataBinding" contract="IMetadataExchange"/>
      </service>
     </services>
     <behaviors>
       <serviceBehaviors>
        <behavior name="returnFaults">
         <serviceDebug includeExceptionDetailInFaults="true"/>
           <serviceMetadata httpsGetEnabled="true"/>
           <serviceTimeouts/>
       </behavior>
      </serviceBehaviors>
     </behaviors>
     <bindings>
        <wsHttpBinding>
           <binding name="TransportSecurity">
                 <security mode="Transport">
                  <transport clientCredentialType="None"/>
                  </security>
            </binding>
          </wsHttpBinding>
     </bindings>
     <diagnostics>
      <messageLogging logEntireMessage="true" 
        maxMessagesToLog="300" logMessagesAtServiceLevel="true" 
        logMalformedMessages="true" logMessagesAtTransportLevel="true"/>
      </diagnostics>
     </system.serviceModel>
    
    //Contract Description
    [ServiceContract]
    interface IService
    {
      [OperationContract]
       string TestCall();
    }
    
    //Implementation
    public class Service:IService
    {
      public string TestCall()
      {
          return "You just called a WCF webservice On SSL
                        (Transport Layer Security)";
      }
    }
    
    //Tracing and message logging
    <system.diagnostics>
      <sources>
          <source name="System.ServiceModel" 
        switchValue="Information,ActivityTracing" propagateActivity="true">
             <listeners>
               <add name="xml"/>
            </listeners>
          </source>
            <source name="System.ServiceModel.MessageLogging">
            <listeners>
                <add name="xml"/>
             </listeners>
             </source>
        </sources>
            <sharedListeners>
              <add initializeData="C:\Service.svclog" 
            type="System.Diagnostics.XmlWriterTraceListener" name="xml"/>
             </sharedListeners>
           <trace autoflush="true"/>
    </system.diagnostics>
