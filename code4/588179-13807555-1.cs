    public class ProductCatalogServiceTest
    {
       [Test]
       public void acceptsSkuAsParameterOnGetRequest()
       {
           var mockCatalog = new MockProductCatalog(); // Hand rolled mock here.
           var catalogService = new ProductCatalogService(mockCatalog);
           catalogService.find("some-sku-from-url")
           
           mockCatalog.assertFindWasCalledWith("some-sku-from-url");
       }
       [Test]
       public void returnsJsonFromGetRequest()
       {
           var mockCatalog = new MockProductCatalog(); // Hand rolled mock here.
           mockCatalog.findShouldReturn(new Product("some-sku-from-url"));
           var mockResponse = new MockHttpResponse(); // Hand rolled mock here.
           var catalogService = new ProductCatalogService(mockCatalog, mockResponse);
           catalogService.find("some-sku-from-url")
           
           mockCatalog.assertWriteWasCalledWith("{ 'sku': 'some-sku-from-url' }");
       }
    }
You've now tested end to end, and test drove the whole thing. I personally would test drive the business logic contained in ProductCatalog and likely skip testing the marshaling as it's likely to all be done by frameworks anyway and it takes little code to tie the controllers into the product catalog. Your mileage may vary.
