    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <configSections>
        <section name="RegisterEventProcessors" type="UnitTestProject1.RegisterEventProcessorsConfig, UnitTestProject1"></section>
      </configSections>
    
      <RegisterEventProcessors>
        <EventProcessors>
          <add event="UnitTestProject1.ClaimantAccountInfoEventType, UnitTestProject1" processor="UnitTestProject1.ClaimantAccountInfoEventProcessor, UnitTestProject1" />
          <add event="UnitTestProject1.EnrollmentEventType, UnitTestProject1" processor="UnitTestProject1.EnrollmentEventProcessor, UnitTestProject1" />
        </EventProcessors>
      </RegisterEventProcessors>
    </configuration>
