        public class MyTests
        {
            private MyData myData;
            private DataProvider dataProvider;
            private IConfiguration configuration;
            [SetUp]
            protected void SetUp()
            {
                // e.g. here stub is created via Moq
                var configurationMock = new Mock<IConfiguration>();
                configurationMock.SetupGet(x => x.MyConnectionString).Returns("test connection string");
                configuration = configurationMock.Object;
                dataProvider = new DataProvider(configuration);
                mysData = new MyData(dataProvider);   
            }
            ...
        }
