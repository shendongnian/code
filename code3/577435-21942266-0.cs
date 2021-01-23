    <?xml version="1.0" encoding="utf-8"?>
    <extension xmlns="urn:newrelic-extension">
      <instrumentation>
        <tracerFactory name="NewRelic.Agent.Core.Tracer.Factories.IgnoreTransactionTracerFactory">
          <match assemblyName="System.Web.Extensions" className="System.Web.Handlers.ScriptResourceHandler">
            <exactMethodMatcher methodName="Throw404" />
          </match>
        </tracerFactory>
      </instrumentation>
    </extension>
