      <configSections>
        <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Microsoft.Practices.Unity.Configuration"/>
      </configSections>
    
    
          <unity>
            <container>
              <register type="IVehicle" mapTo="Car" name="myCarKey" />
              <register type="IVehicle" mapTo="Truck" name="myTruckKey" />
            </container>
          </unity>
