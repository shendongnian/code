    [TestFixture]
    public class LoadIntoInstance
    {
        public class Template
        {
            public string Name { get; set; }
        }
        public class Person
        {
            public string Name { get; set; }
            public string OtherData { get; set; }
        }        
        [Test]
        public void Should_load_int_instance()
        {
            Mapper.CreateMap<Template, Person>()
                .ForMember(d=>d.OtherData, opt=>opt.Ignore());
            Mapper.CreateMap<Person, Person>()
                .ForAllMembers(opt=>opt.Condition(ctx=>ctx.DestinationValue==null));
            Mapper.AssertConfigurationIsValid();
            var template = new Template {Name = "template"};
            var basePerson = Mapper.Map<Person>(template);
            var noNamePerson = new Person {OtherData = "other"};
            var result = Mapper.Map(basePerson, noNamePerson);
            result.Should().Be.SameInstanceAs(noNamePerson);
            result.Satisfy(r =>
                           r.Name == "template" &&
                           r.OtherData == "other");
        }
    }
