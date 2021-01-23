         <!-- AppFabric Config -->
      <system.serviceModel>
        <diagnostics etwProviderId="830b12d1-bb5b-4887-aa3f-ab508fd4c8ba">
          <endToEndTracing propagateActivity="true" activityTracing="true" messageFlowTracing="true" />
        </diagnostics>
        <behaviors>
          <serviceBehaviors>
            <behavior name="">
              <etwTracking profileName="EndToEndMonitoring Tracking Profile" />
              <serviceMetadata httpGetEnabled="true" />
            </behavior>
          </serviceBehaviors>
        </behaviors>
      </system.serviceModel>
      <microsoft.applicationServer>
        <monitoring>
          <default enabled="true" connectionStringName="ApplicationServerMonitoringConnectionString" monitoringLevel="EndToEndMonitoring" />
        </monitoring>
      </microsoft.applicationServer>
