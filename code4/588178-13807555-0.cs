    public class ProductCatalogTest
    {
        [Test]
        public void allowsNewProductsToBeAdded() {}
        [Test]
        public void allowsUpdatesToExistingProducts() {}
        [Test]
        public void allowsFindingSpecificProductsUsingSku () {}
    }
I won't go into detail about how to implement the tests and production code here, but this is a starting point. Once you've got the ProductCatalog production class worked out, you can turn your attention to the technical details like making a web service and marshaling your JSON.
