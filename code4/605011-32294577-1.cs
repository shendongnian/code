    [TestClass]
    public class TenantDataBasedTests : BaseIntegrationTest
    {
        [TestMethod]
        public void GetTenantForName_ReturnsOneRecord()
        {
            // ARRANGE
            const int expectedCount = 1;
            const string expectedName = "Me";
            // Build the paraemeters object
            var parameters = new GetTenantForTenantNameParameters
            {
                TenantName = expectedName
            };
            // get an instance of the stored procedure passing the parameters
            var procedure = new GetTenantForTenantNameProcedure(parameters);
            // Initialise the procedure name and schema from procedure attributes
            procedure.InitializeFromAttributes();
            // Add some tenants to context so we have something for the procedure to return!
            AddTenentsToContext(Context);
            // ACT
            // Get the results by calling the stored procedure from the context extention method 
            var results = Context.ExecuteStoredProcedure(procedure);
            // ASSERT
            Assert.AreEqual(expectedCount, results.Count);
        }
    }
    internal class GetTenantForTenantNameParameters
    {
        [Name("TenantName")]
        [Size(100)]
        [ParameterDbType(SqlDbType.VarChar)]
        public string TenantName { get; set; }
    }
    [Schema("app")]
    [Name("Tenant_GetForTenantName")]
    internal class GetTenantForTenantNameProcedure
        : StoredProcedureBase<TenantResultRow, GetTenantForTenantNameParameters>
    {
        public GetTenantForTenantNameProcedure(
            GetTenantForTenantNameParameters parameters)
            : base(parameters)
        {
        }
    }
