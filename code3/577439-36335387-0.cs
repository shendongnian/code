    <tracerFactory name="NewRelic.Agent.Core.Tracer.Factories.IgnoreTransactionTracerFactory">
        <match assemblyName="SignalR.Hosting.AspNet" className="SignalR.Hosting.AspNet.AspNetHandler">
            <exactMethodMatcher methodName="ProcessRequestAsync"/>
        </match>
    </tracerFactory>
