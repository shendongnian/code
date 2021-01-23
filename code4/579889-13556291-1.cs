    namespace StackOverflow.ListUnit
    {
        using System.Collections.Generic;
        using System.Linq;
        using AutoMapper;
        using NUnit.Framework;
        [TestFixture]
        public class MappingTests
        {
            [Test]
            public void AutoMapper_Configuration_IsValid()
            {
                Mapper.Initialize(m => m.AddProfile<MyProfile>());
                Mapper.AssertConfigurationIsValid();
            }
            [Test]
            public void AutoMapper_Mapping_IsValid()
            {
                Mapper.Initialize(m => m.AddProfile<MyProfile>());
                Mapper.AssertConfigurationIsValid();
                var unit = new Unit
                    {
                        UnitId = 123,
                        Name = "Stack Overflow Rocks",
                        HasChildren = true,
                        IsFolder = true,
                        Units =
                            new List<Unit>
                                {
                                    new Unit
                                        {
                                            UnitId = 123123,
                                            Name = "I'm the first baby",
                                            HasChildren = false,
                                            IsFolder = false,
                                        },
                                    new Unit
                                        {
                                            UnitId = 123321,
                                            Name = "I'm the second baby",
                                            HasChildren = false,
                                            IsFolder = false,
                                        }
                                }
                    };
                var unitViewModels = new List<UnitTreeViewModel>
                    {
                        Mapper.Map<Unit, UnitTreeViewModel>(unit)
                    };
                unitViewModels.AddRange(
                    unit.Units.Select(Mapper.Map<Unit, UnitTreeViewModel>));
                Assert.That(unitViewModels, Is.Not.Null);
                Assert.That(unitViewModels.Count(), Is.EqualTo(3));
                var unitViewModel = unitViewModels.First(x => x.UnitId == 123);
                Assert.That(unitViewModel, Is.Not.Null);
                Assert.That(unitViewModel.Name, Is.EqualTo("Stack Overflow Rocks"));
                unitViewModel = unitViewModels.First(x => x.UnitId == 123123);
                Assert.That(unitViewModel, Is.Not.Null);
                Assert.That(unitViewModel.Name, Is.EqualTo("I'm the first baby"));
                unitViewModel = unitViewModels.First(x => x.UnitId == 123321);
                Assert.That(unitViewModel, Is.Not.Null);
                Assert.That(unitViewModel.Name, Is.EqualTo("I'm the second baby"));
            }
        }
    }
