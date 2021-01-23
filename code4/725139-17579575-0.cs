    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Moq;
    using NUnit.Framework;
    
    namespace StackOverflowExample.Moq
    {
        public class Product
        {
            public string UrlRewrite { get; set; }
            public string Title { get; set; }
        }
    
        public interface IProductQuery
        {
            Product GetByFilter(Expression<Func<Product, bool>> filter);
        }
    
        public class Controller
        {
            private readonly IProductQuery _queryProvider;
            public Controller(IProductQuery queryProvider)
            {
                _queryProvider = queryProvider;
            }
    
            public Product GetProductByUrl(string urlRewrite)
            {
                return _queryProvider.GetByFilter(x => x.UrlRewrite == urlRewrite);
            }
        }
    
        [TestFixture]
        public class ExpressionMatching
        {
            [Test]
            public void MatchTest()
            {
                //arrange
                const string GOODURL = "goodurl";
                var goodProduct = new Product {UrlRewrite = GOODURL};
                var products = new List<Product>
                    {
                        goodProduct
                    };
    
                var qp = new Mock<IProductQuery>();
                qp.Setup(q => q.GetByFilter(It.IsAny<Expression<Func<Product, bool>>>()))
                  .Returns<Expression<Func<Product, bool>>>(q =>
                      {
                          var query = q.Compile();
                          return products.First(query);
                      });
    
                var testController = new Controller(qp.Object);
    
                //act
                var foundProduct = testController.GetProductByUrl(GOODURL);
    
                //assert
                Assert.AreSame(foundProduct, goodProduct);
            }
        }
    } 
