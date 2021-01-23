    [TestFixture]
    public class Test
    {
        [Test]
        public void CreateTenentAlreadyExistsTest()
        {
            var tenentMock = new Mock<ITenant>();
            var repoMock = new Mock<IRepository<ITenant>>();
            tenentMock.Setup(t => t.BusinessIdentificationNumber).Returns("aNumber");
            repoMock.Setup(r => r.FindBy(It.Is<System.Func<ITenant, bool>>(func1 => func1.Invoke(tenentMock.Object)))).Returns(tenentMock.Object);
            var tenantCreationService = new TenantCreationService(repoMock.Object);
            tenantCreationService.CreateTenant(tenentMock.Object);
            tenentMock.VerifyAll();
            repoMock.VerifyAll();
        }
    }
    public interface ITenant
    {
        string BusinessIdentificationNumber { get; set; }
    }
    public class Tenant : ITenant
    {
        public string BusinessIdentificationNumber { get; set; }
    }
    public interface IRepository<T>
    {
        T FindBy(System.Func<T, bool> func);
    }
    public class TenantCreationService : ITenantCreationService
    {
        private readonly IRepository<ITenant> _tenantRepository;
        public TenantCreationService(IRepository<ITenant> tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }
        public void CreateTenant(ITenant tenant)
        {
            var existingTenant =
                _tenantRepository.FindBy(t => t.BusinessIdentificationNumber == tenant.BusinessIdentificationNumber);
            if (existingTenant == null)
            {
                //do stuff
            }
        }
    }
    public interface ITenantCreationService
    {
        void CreateTenant(ITenant tenant);
    }
