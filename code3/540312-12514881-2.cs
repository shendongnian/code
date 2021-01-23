    <system.serviceModel> 
    <services>
      <service name="namespace.RssArticleService"
               behaviorConfiguration="RssArticleServiceBehavior">
        <endpoint address=""
                  binding="basicHttpBinding"
                  contract="namespace.IRssArticleService"/>
      </service>
    </services>
    <serviceBehaviors>
       <behavior name="RssArticleServiceBehavior">
          <serviceMetadata httpGetEnabled="true" httpsGetEnabled="true" />
          <serviceDebug includeExceptionDetailInFaults="true" />
       </behavior>
     </serviceBehaviors>
     <serviceHostingEnvironment aspNetCompatibilityEnabled="true" multipleSiteBindingsEnabled="true"/>
    </system.serviceModel>
