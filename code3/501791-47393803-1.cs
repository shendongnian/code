    // _mockShopService.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(() => null);
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    
    public interface IShopService
    {
        Product GetProduct(string productId);
    }
    
    public class ShopService : IShopService
    {
    	public Product GetProduct(string productId)
        {
            if (string.IsNullOrWhiteSpace(productId))
            {
                return new Product();
            }
    
            return new Product { Id = "8160807887984", Name = "How to return null in Moq" };
        }
    }
    
    public class Shop
    {
        private static IShopService _shopService;
    
        public Shop(IShopService shopService)
        {
            _shopService = shopService;
        }
    
        public Product GetProduct(string productId)
        {
            Product product = _shopService.GetProduct(productId);
    
            return product;
        }
    }
    
    [TestClass]
    public class ShopTests
    {
        Mock<IShopService> _mockShopService;
    
        [TestInitialize]
        public void Setup()
        {
            _mockShopService = new Mock<IShopService>();
        }
    
        [TestMethod]
        public void ShopService_GetProduct_Returns_null()
        {
            //Arrange
            Shop shop = new Shop(_mockShopService.Object);
    
            //This is how we return null --- all other code above is to bring this line of code home
            _mockShopService.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(() => null);
    
            //Act
            var actual = shop.GetProduct(It.IsAny<string>());
    
            //Assert
    
            Assert.IsNull(actual);
        }
    }
