    using AutoMapper;
    using NUnit.Framework;
    namespace Tests.UI
    {
        [TestFixture]
        class AutomapperTests
        {
          public class Person
            {
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public int? Foo { get; set; }
            }
            [Test]
            public void TestNullIgnore()
            {
                Mapper.CreateMap<Person, Person>()
                        .ForAllMembers(opt => opt.Condition(srs => !srs.IsSourceValueNull));
                var sourcePerson = new Person
                {
                    FirstName = "Bill",
                    LastName = "Gates",
                    Foo = null
                };
                var destinationPerson = new Person
                {
                    FirstName = "",
                    LastName = "",
                    Foo = 1
                };
                Mapper.Map(sourcePerson, destinationPerson);
                Assert.That(destinationPerson,Is.Not.Null);
                Assert.That(destinationPerson.Foo,Is.EqualTo(1));
            }
        }
    }
