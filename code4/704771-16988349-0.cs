    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using NUnit.Framework;
    using SharpTestsEx;
    
    namespace StackOverflowExample.Automapper
    {
        public class OrderViewModel
        {
            public string Name { get; set; }
            public string ContactDetails { get; set; }
            public List<FunkyThingViewModel> FunkyThingViewModels { get; set; }
        }
    
        public class FunkyThingViewModel
        {
            public string ThingName { get; set; }
            public string Colour { get; set; }
            public string Size { get; set; }
        }
    
        public class Order
        {
            public string Name { get; set; }
            public string ContactDetails { get; set; }
            public string ThingName { get; set; }
            public string Colour { get; set; }
            public string Size { get; set; }
        }
    
        [TestFixture]
        public class FlattenWithListTests
        {
            [Test]
            public void FlattenListTest()
            {
                //arrange
                var source = new OrderViewModel
                    {
                        Name = "name",
                        ContactDetails = "contact",
                        FunkyThingViewModels = new List<FunkyThingViewModel>
                            {
                                new FunkyThingViewModel {Colour = "red"},
                                new FunkyThingViewModel {Colour = "blue"}
                            }
                    };
    
                Mapper.CreateMap<FunkyThingViewModel, Order>();
                Mapper.CreateMap<OrderViewModel, Order>();
                Mapper.CreateMap<OrderViewModel, List<Order>>()
                      .ConvertUsing(om => om.FunkyThingViewModels.Select(
                          ftvm =>
                              {
                                  var order = Mapper.Map<Order>(om);
                                  Mapper.Map(ftvm, order);
                                  return order;
                              }).ToList());
    
                //act
                var mapped = Mapper.Map<List<Order>>(source);
    
                //assert
                mapped[0].Satisfy(m =>
                                  m.Name == source.Name &&
                                  m.ContactDetails == source.ContactDetails &&
                                  m.Colour == "red");
                mapped[1].Satisfy(m =>
                                  m.Name == source.Name &&
                                  m.ContactDetails == source.ContactDetails &&
                                  m.Colour == "blue");
            }
        }
    }
