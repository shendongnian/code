    <configuration>
      <configSections>
        <section name="MsmqTransportConfig" type="NServiceBus.Config.MsmqTransportConfig, NServiceBus.Core" />
        <section name="UnicastBusConfig" type="NServiceBus.Config.UnicastBusConfig, NServiceBus.Core" />
      </configSections>
      <MsmqTransportConfig ErrorQueue="error" NumberOfWorkerThreads="1" MaxRetries="5" />
      <UnicastBusConfig ForwardReceivedMessagesTo="">
        <MessageEndpointMappings>
          <add Messages="TrackEventPublisher.EventPublisher.InternalMessages" Endpoint="EventPublisher" />
        </MessageEndpointMappings>
      </UnicastBusConfig>
    </configuration>
