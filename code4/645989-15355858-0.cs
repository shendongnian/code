	<system.webServer>
		<validation validateIntegratedModeConfiguration="false" />
		<handlers>
			<remove name="ChartImageHandler" />
			<add name="ChartImageHandler" preCondition="integratedMode" verb="GET,HEAD,POST" path="ChartImg.axd" type="System.Web.UI.DataVisualization.Charting.ChartHttpHandler, System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
		</handlers>
        <security>
            <authentication>
                <basicAuthentication enabled="false" />
                <windowsAuthentication enabled="false" />
            </authentication>
        </security>
        <rewrite>
			<rule name="Rewrite aspx" stopProcessing="true">
				<match url="^([a-z0-9/]+).aspx$" ignoreCase="true"/>
				<action type="Redirect" url="{R:1}"/>
			</rule>
			
           
           
        </rewrite>
        <urlCompression doStaticCompression="true" doDynamicCompression="true" />
			</system.webServer>
	<appSettings>
		
		<add key="ChartImageHandler" value="storage=file;timeout=20;" />
	</appSettings>
	<system.web>
		
		
		<httpHandlers>
			<add path="ChartImg.axd" verb="GET,HEAD,POST" type="System.Web.UI.DataVisualization.Charting.ChartHttpHandler, System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" validate="false" />
		</httpHandlers>
		<customErrors mode="On" defaultRedirect="ErrorPage" />
		<!-- 
            Set compilation debug="true" to insert debugging 
            symbols into the compiled page. Because this 
            affects performance, set this value to true only 
            during development.
        -->
		<compilation debug="true" targetFramework="4.0">
			<assemblies>
				<add assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
			</assemblies>
		</compilation>
		
		<authentication mode="Windows" />
		
		<pages controlRenderingCompatibilityVersion="3.5" clientIDMode="AutoID">
			<controls>
				<add tagPrefix="asp" namespace="System.Web.UI.DataVisualization.Charting" assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
			</controls>
		</pages>
		<httpRuntime maxRequestLength="10480" />
        <identity impersonate="false" />
	</system.web>
			
	<!-- 
        The system.webServer section is required for running ASP.NET AJAX under Internet
        Information Services 7.0.  It is not necessary for previous version of IIS.
    -->
	
