    <system.serviceModel>
       <behaviors>
         <serviceBehaviors>
           <behavior name="TestLargeWCF.Web.MyServiceBehavior">
             <serviceMetadata httpGetEnabled="true"/>
             <serviceDebug includeExceptionDetailInFaults="false"/>
           </behavior>
         </serviceBehaviors>
       </behaviors>
       <bindings>
         <customBinding>
           <binding name="customBinding0">
             <binaryMessageEncoding />
             <!-- Start change -->
             <httpTransport maxReceivedMessageSize="2097152"
                            maxBufferSize="2097152"
                            maxBufferPoolSize="2097152"/>
             <!-- Stop change -->
           </binding>
         </customBinding>
       </bindings>
       <serviceHostingEnvironment aspNetCompatibilityEnabled="true"/>
       <services>
         <service behaviorConfiguration="Web.MyServiceBehavior" name="TestLargeWCF.Web.MyService">
           <endpoint address=""
                    binding="customBinding"
                    bindingConfiguration="customBinding0"
                    contract="TestLargeWCF.Web.MyService"/>
           <endpoint address="mex"
                    binding="mexHttpBinding"
                    contract="IMetadataExchange"/>
         </service>
       </services>
     </system.serviceModel> 
