    Dim aSource As New SqlDataSource
     aSource.ConnectionString = {your connection string})
     aSource.ProviderName = "System.Data.SqlClient"
     aSource.SelectCommand = {Your stored procedure name}
     aSource.SelectCommandType = SqlDataSourceCommandType.StoredProcedure
     aSource.SelectParameters.Add(New System.Web.UI.WebControls.Parameter("ID", Data.DbType.String, Request.QueryString(0)))
