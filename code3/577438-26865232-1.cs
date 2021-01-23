    <?xml version="1.0" encoding="utf-8"?>
    <extension xmlns="urn:newrelic-extension">
    	<instrumentation>
    
    		<!-- Optional for basic traces. -->
    		<tracerFactory name="NewRelic.Agent.Core.Tracer.Factories.IgnoreTransactionTracerFactory">
    			<match assemblyName="Microsoft.AspNet.SignalR.Core" className="Microsoft.AspNet.SignalR.PersistentConnection">
    				<exactMethodMatcher methodName="ProcessRequest"/>
    			</match>
    		</tracerFactory>
    	</instrumentation>
    </extension>
