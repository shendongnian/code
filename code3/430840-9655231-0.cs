    [TestClass]
    public class TestClass
    {
        public DataSourceAttribute DataSource
        {
            get
            {
                return (DataSourceAttribute)Attribute.GetCustomAttribute(typeof(TestClass).
                    GetMethod("TestMethod"), typeof(DataSourceAttribute));
            }
        }
        [DataSource(PROVIDER_INVARIANT_NAME, CONNECTION_STRING, 
            "Test Case#", DataAccessMethod.Sequential), TestMethod]
        public void TestMethod()
        {
            string TestCaseId = DataSource.TableName;
        }
    }
