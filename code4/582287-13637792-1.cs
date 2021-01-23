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
            var functions = new List<Function>
                {
                    new Function
                        {
                            Comment = "Stack Overflow Rocks",
                            EndDate = new DateTime(2012, 01, 01),
                            ExaminationDate = new DateTime(2012, 02, 02),
                            Id = 1,
                            Name = "Number 1",
                            Place = "Here, there and everywhere",
                            StartDate = new DateTime(2012, 03, 03)
                        },
                    new Function
                        {
                            Comment = "As do I",
                            EndDate = new DateTime(2013, 01, 01),
                            ExaminationDate = new DateTime(2013, 02, 02),
                            Id = 2,
                            Name = "Number 2",
                            Place = "Nowhere",
                            StartDate = new DateTime(2013, 03, 03)
                        }
                };
            var functionDtos = functions
                .AsQueryable()
                .OrderBy(x => x.Id)
                .Skip(1)
                .Take(1)
                .ToList()
                .Select(Mapper.Map<FunctionDto>);
            Assert.That(functionDtos, Is.Not.Null);
            Assert.That(functionDtos.Count(), Is.EqualTo(1));
            Assert.That(functionDtos.First().Id, Is.EqualTo(2));
        }
    }
