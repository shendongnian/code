    <compilation defaultLanguage="c#" batch="false" targetFramework="4.0" debug="true">
      <assemblies>
    	<!-- ASP.NET 4.0 Assemblies -->
    	<add assembly="System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" />
    	<add assembly="System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
    	<add assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
    	<add assembly="System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
    	<add assembly="System.Data.DataSetExtensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
    	<add assembly="System.Web.Extensions.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
    	<add assembly="System.Web.Abstractions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
    	<add assembly="System.Web.Helpers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
    	<add assembly="System.Web.Routing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
    	<add assembly="System.Web.Mvc, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
    	<add assembly="System.Web.WebPages, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
      </assemblies>
      <!-- Added in Umbraco 4.6.2 -->
      <buildProviders>
    	<add extension=".cshtml" type="umbraco.MacroEngines.RazorBuildProvider, umbraco.MacroEngines" />
    	<add extension=".vbhtml" type="umbraco.MacroEngines.RazorBuildProvider, umbraco.MacroEngines" />
    	<add extension=".razor" type="umbraco.MacroEngines.RazorBuildProvider, umbraco.MacroEngines" />
      </buildProviders>
      <!-- End of added in Umbraco 4.6.2 -->
    </compilation>
