    <?xml version="1.0" encoding="utf-8"?>
    <extension xmlns="urn:newrelic-extension">
        <instrumentation>
            <tracerFactory name="NewRelic.Agent.Core.Tracer.Factories.IgnoreTransactionTracerFactory">
                <match assemblyName="Microsoft.AspNet.SignalR.Core" className="Microsoft.AspNet.SignalR.PersistentConnection">
                    <exactMethodMatcher methodName="AuthorizeRequest"/>
                </match>
    			 <match assemblyName="Microsoft.AspNet.SignalR.Core" className="Microsoft.AspNet.SignalR.Hubs.HubDispatcher">
                    <exactMethodMatcher methodName="AuthorizeRequest"/>
                </match>
            </tracerFactory>
        </instrumentation>
    </extension>
