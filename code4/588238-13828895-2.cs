        public class MyTests
        {
            private MyData myData;
            private DataProvider dataProvider;
            private IConfiguration configuration;
            [SetUp]
            protected void SetUp()
            {
                // e.g. here stub is created via Moq
                configuration = new Mock<IConfiguration>();
                configuration.SetupGet(x => x.MyConnectionString).Returns("test connection string");                
                dataProvider = new DataProvider(configuration);
                mysData = new MyData(dataProvider);   
            }
            ...
        }
