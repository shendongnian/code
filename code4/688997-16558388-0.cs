    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using NUnit.Framework;
    namespace StackOverFlowAnswers
    {
        public class LineItem
        {
            public int Id { get; set; }
            public string ProductId { get; set; }
            public int Amount { get; set; }
        }
        public class Model
        {
            public int Id { get; set; }
            public string ProductId { get; set; }
            public string Amount { get; set; }
        }
        public class AutoMappingTests
        {
            [TestFixtureSetUp]
            public void TestFixtureSetUp()
            {
                Mapper.CreateMap<Model, LineItem>()
                      .ForMember(x => x.Amount, opt => opt.ResolveUsing<StringToInteger>());
            }
            [Test]
            public void TestBadStringToDefaultInteger()
            {
                // Arrange
                var model = new Model() {Id = 1, ProductId = "awesome-product-133-XP", Amount = "EVIL STRING, MWUAHAHAHAH"};
                // Act
                LineItem mapping1 = Mapper.Map<LineItem>(model);
                // Assert
                Assert.AreEqual(model.Id, mapping1.Id);
                Assert.AreEqual(model.ProductId, mapping1.ProductId);
                Assert.AreEqual(0, mapping1.Amount);
                // Arrange
                model.Amount = null; // now we test null, which we said in options to map from null to -1
                // Act
                LineItem mapping2 = Mapper.Map<LineItem>(model);
                // Assert
                Assert.AreEqual(-1, mapping2.Amount);
            }
        }
        public class StringToInteger : ValueResolver<Model, int>
        {
            protected override int ResolveCore(Model source)
            {
                if (source.Amount == null)
                {
                    return -1;
                }
                int value;
                if (int.TryParse(source.Amount, out value))
                {
                    return value; // Wahayy!!
                }
                return 0; // return 0 if it could not parse!
            }
        }
    }
