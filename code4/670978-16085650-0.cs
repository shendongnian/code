    <system.serviceModel>
        <diagnostics performanceCounters ="All"/>  
        <services>
          <service behaviorConfiguration ="Default" name ="Service.IService1">
            <endpoint address="" behaviorConfiguration="Web" binding ="basicHttpBinding" contract ="ServiceReference1.IService1"></endpoint>
            <host>
              <baseAddresses>                
              </baseAddresses>
            </host>
          </service>      
        </services>
        <behaviors>      
          <serviceBehaviors>
            <behavior name ="Default">
          
              <serviceThrottling maxConcurrentCalls ="100" maxConcurrentSessions ="100"/>
              <!-- To avoid disclosing metadata information, set the value below to false and remove the metadata endpoint above before deployment -->
              <serviceMetadata httpGetEnabled="true" />
              <!-- To receive exception details in faults for debugging purposes, set the value below to true.  Set to false before deployment to avoid disclosing exception information -->
              <serviceDebug includeExceptionDetailInFaults="false"/>
            </behavior>
          </serviceBehaviors>
          <endpointBehaviors>
            <behavior name ="Web"></behavior>
          </endpointBehaviors>
        </behaviors>
        <serviceHostingEnvironment  multipleSiteBindingsEnabled="true" />
    
      </system.serviceModel>
