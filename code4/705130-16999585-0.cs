    <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
        <!-- General aliases -->
        <alias alias="string" type="System.String, mscorlib" />
        <alias alias="singleton" type="Microsoft.Practices.Unity.ContainerControlledLifetimeManager, Microsoft.Practices.Unity, Version=2.1.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
        <!-- Interface aliases -->
        <alias alias="ISampleService" type="MyApp.Api.Interfaces.Services.ISampleService, MyApp.Api" />
        <alias alias="IMessagingService" type="MyApp.Api.Interfaces.Services.IMessagingService, MyApp.Api" />
        <!-- Concrete implementations aliases -->
        <alias alias="SampleServiceImpl" type="MyApp.BizLayer.SampleService, MyApp.BizLayer" />
        <alias alias="MessagingServiceImpl" type="MyApp.BizLayer.SampleService, MyApp.BizLayer" />
        <container>
           <register type="SampleServiceImpl" mapTo="ISampleService"/>
           <register type="MessagingServiceImpl" mapTo="IMessagingService">
              <lifetime type="singleton" />
           </register>
        </container>
    </unity>
