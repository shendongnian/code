    <configSections>
         <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Microsoft.Practices.Unity.Configuration" />
    </configSections>
    <unity>
		<container>
            <register type="MyApp.MainWindow, MyApp">
				<lifetime type="singleton" />
			</register>
            <register name="UnityResolver" type="MyApp.Core.Interface.IResolver, MyApp.Core.Interface" mapTo="Avelyn.Core.Container.UnityResolver, Avelyn.Core" />
            <register name="NinjectResolver" type="MyApp.Core.Interface.IResolver, MyApp.Core.Interface" mapTo="Avelyn.Core.Container.NinjectResolver, Avelyn.Core" />
        </container>
	</unity>
