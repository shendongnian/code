    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using NUnit.Framework;
    using SharpTestsEx;
    
    namespace StackOverflowExample
    {
        public class House
        {
            public string Address { get; set; }
        }
    
        public class Person
        {
            public IList<House> OwnedHouse { get; set; }
        }
    
        public class HouseDto
        {
            public string Address { get; set; }
        }
    
        public class PersonDto
        {
            public IList<HouseDto> OwnedHouse { get; set; }
        }
    
        [TestFixture]
        public class AutomapperTest
        {
            public interface IHouseListConverter : ITypeConverter<IList<House>, IList<HouseDto>>
            {
            }
    
            public class HouseListConverter : IHouseListConverter
            {
                private readonly IDictionary<House, HouseDto> existingMappings;
    
                public HouseListConverter(IDictionary<House, HouseDto> existingMappings)
                {
                    this.existingMappings = existingMappings;
                }
    
                public IList<HouseDto> Convert(ResolutionContext context)
                {
                    var houses = context.SourceValue as IList<House>;
                    if (houses == null)
                    {
                        return null;
                    }
    
                    var dtos = new List<HouseDto>();
                    foreach (var house in houses)
                    {
                        HouseDto mapped = null;
                        if (existingMappings.ContainsKey(house))
                        {
                            mapped = existingMappings[house];
                        }
                        else
                        {
                            mapped = Mapper.Map<HouseDto>(house);
                            existingMappings[house] = mapped;
                        }
                        dtos.Add(mapped);
                    }
    
                    return dtos;
                }
            }
    
            public class ConverterFactory
            {
                private readonly IHouseListConverter resolver;
                public ConverterFactory()
                {
                    resolver = new HouseListConverter(new Dictionary<House, HouseDto>());
                }
    
                public object Resolve(Type t)
                {
                    return t == typeof(IHouseListConverter) ? resolver : null;
                }
            }
    
            [Test]
            public void CustomResolverTest()
            {
                Mapper.CreateMap<House, HouseDto>();
                Mapper.CreateMap<IList<House>, IList<HouseDto>>().ConvertUsing<IHouseListConverter>();
                Mapper.CreateMap<Person, PersonDto>();
    
                var house = new House {Address = "any"};
                var john = new Person {OwnedHouse = new List<House> {house}};
                var will = new Person { OwnedHouse = new List<House> { house } };
    
                var converterFactory = new ConverterFactory();
                var johnDto = Mapper.Map<PersonDto>(john, o=>o.ConstructServicesUsing(converterFactory.Resolve));
                var willDto = Mapper.Map<PersonDto>(will, o=>o.ConstructServicesUsing(converterFactory.Resolve));
    
                johnDto.OwnedHouse[0].Should().Be.SameInstanceAs(willDto.OwnedHouse[0]);
                johnDto.OwnedHouse[0].Address.Should().Be("any");
            }
        }
    }  
