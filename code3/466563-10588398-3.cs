    [TestFixture]
    public class MappingTests
    {
        private ISessionFactory _factory;
        #region Setup/Teardown for fixture
        [TestFixtureSetUp]
        public void SetUpFixture()
        {
            if (File.Exists("test.db")) File.Delete("test.db");
            _factory = Fluently.Configure()
                .Database(() => SQLiteConfiguration.Standard
                                    .UsingFile("test.db")
                                    .ShowSql()
                                    .FormatSql())
                .Mappings(mappings => mappings.FluentMappings
                                          .AddFromAssemblyOf<PersonMap>())
                .ExposeConfiguration(config =>
                                         {
                                             var exporter = new SchemaExport(config);
                                             exporter.Execute(true, true, false);
                                         })
                .BuildSessionFactory();
        }
        [TestFixtureTearDown]
        public void TearDownFixture()
        {
            _factory.Close();
        }
        #endregion
        #region Setup/Teardown for each test
        [SetUp]
        public void SetUpTest()
        {
        }
        [TearDown]
        public void TearDownTest()
        {
        }
        #endregion
        [Test]
        public void Should_create_and_retrieve_Person()
        {
            var expected = new Person
            {
                FirstName = "Mike",
                LastName = "G"
            };
            using (var session = _factory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                session.SaveOrUpdate(expected);
                tx.Commit();
            }
            expected.Id.Should().BeGreaterThan(0);
            using (var session = _factory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var actual = session.Get<Person>(expected.Id);
                actual.Should().NotBeNull();
                actual.ShouldHave().AllProperties().EqualTo(expected);
            }
        }
        [Test]
        public void Should_create_and_retrieve_Roles()
        {
            // Arrange
            var expected = new Person
                             {
                                 FirstName = "Mike",
                                 LastName = "G"
                             };
            var expectedManager = new Manager
                               {
                                   Division = "One",
                                   Status = "Active"
                               };
            var expectedUser = new User
                                   {
                                       LoginName = "mikeg",
                                       Password = "test123"
                                   };
            Person actual;
            // Act
            expected.AddRole(expectedManager);
            expected.AddRole(expectedUser);
            using (var session = _factory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                session.SaveOrUpdate(expected);
                tx.Commit();
            }
            using (var session = _factory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                actual = session.Get<Person>(expected.Id);
                // ignore this; just forcing the Roles collection to be lazy loaded before I kill the session.
                actual.Roles.Count();
            }
            // Assert
            actual.Roles.OfType<Manager>().First().Should().Be(expectedManager);
            actual.Roles.OfType<Manager>().First().ShouldHave().AllProperties().But(c => c.Person).EqualTo(expectedManager);
            actual.Roles.OfType<User>().First().Should().Be(expectedUser);
            actual.Roles.OfType<User>().First().ShouldHave().AllProperties().But(c => c.Person).EqualTo(expectedUser);
        }
    }
