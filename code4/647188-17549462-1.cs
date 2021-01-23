	<system.web>
		<compilation debug="true" targetFramework="4.0">
			<assemblies>
				<add assembly="System.Web.Abstractions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
				<add assembly="System.Web.Routing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
				<add assembly="System.Data.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"/>
				<add assembly="System.Web.Mvc, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
			</assemblies>
			<buildProviders>
				<add extension=".cshtml" type="System.Web.WebPages.Razor.RazorBuildProvider, System.Web.WebPages.Razor"/>
			</buildProviders>
		</compilation>
	</system.web>
