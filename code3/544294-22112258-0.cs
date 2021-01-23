        Dim EfBuilder As New System.Data.EntityClient.EntityConnectionStringBuilder("metadata=res://*/VMware.VmEf.csdl|res://*/VMware.VmEf.ssdl|res://*/VMware.VmEf.msl;provider=System.Data.SqlClient;provider connection string=""data source=none;initial catalog=none;integrated security=True;multipleactiveresultsets=True;App=EntityFramework""")
       Dim SqlBuilder As New Data.SqlClient.SqlConnectionStringBuilder(EfBuilder.ProviderConnectionString)
        					SqlBuilder.DataSource = serverName
        					SqlBuilder.InitialCatalog = databaseName
        					EfBuilder.ProviderConnectionString = SqlBuilder.ConnectionString
        					Using vmCtx As New VmEfConn(EfBuilder.ConnectionString)
    					
