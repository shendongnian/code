	<system.data>
	    <DbProviderFactories>
            <remove invariant="Oracle.DataAccess.Client" />
            <add name="Oracle Data Provider for .NET"
                invariant="Oracle.DataAccess.Client"
                description="Oracle Data Provider for .NET"
                type="Oracle.DataAccess.Client.OracleClientFactory, Oracle.DataAccess, Version=2.112.3.0, Culture=neutral, PublicKeyToken=89b483f429c47342"/>
	    </DbProviderFactories>
	</system.data>
