    using System.Data.EntityClient;
    using System.Data.SqlClient;
    ...
    private string GetADOConnectionString()
    {
        SalesSyncEntities ctx = new SalesSyncEntities(); //create your entity object here
        EntityConnection ec = (EntityConnection)ctx.Connection;
        SqlConnection sc = (SqlConnection)ec.StoreConnection; //get the SQLConnection that your entity object would use
        string adoConnStr = sc.ConnectionString;
        return adoConnStr;
    }
