    <configSections>
        <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Microsoft.Practices.Unity.Configuration"/>
      </configSections>
    
    <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
        <assembly  name="Ecommerce_WCF"/>
        <assembly  name="Ecommerce_WCF_Test"/>
    
        <alias alias="IDatabase" type="Ecommerce_WCF.IDatabase, Ecommerce_WCF" />
        <alias alias="Database" type="Ecommerce_WCF.Database, Ecommerce_WCF" />
        <alias alias="DatabaseMock" type="Ecommerce_WCF.DatabaseMock, Ecommerce_WCF" />
        
        <container>
          <register type="IDatabase" mapTo="Database" />
    
    
          <!--<register type="IDatabase" mapTo="DatabaseMock" />-->
        </container>
      </unity>
