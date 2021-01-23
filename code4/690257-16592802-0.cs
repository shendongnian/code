    namespace Stackoverflow
    {
        using AutoMapper;
        using SharpTestsEx;
        using NUnit.Framework;
    
        [TestFixture]
        public class MapperTest
        {
            public class Dto
            {
                public int Int { get; set; }
                public string StrEmpty { get; set; }
                public string StrNull { get; set; }
                public string StrAny { get; set; }
            }
    
            public class Model
            {
                public int Int { get; set; }
                public string StrEmpty { get; set; }
                public string StrNull { get; set; }
                public string StrAny { get; set; }
            }
    
            [Test]
            public void MapWithNulls()
            {
                var dto = new Dto
                    {
                        Int = 100,
                        StrNull = null,
                        StrEmpty = string.Empty,
                        StrAny = "any"
                    };
    
                Mapper.CreateMap<Dto, Model>()
                      .ForAllMembers(m => m.Condition(ctx =>
                                                      ctx.SourceType != typeof (string)
                                                      || ctx.SourceValue != string.Empty));
    
                var model = Mapper.Map<Dto, Model>(dto);
    
                model.Satisfy(m =>
                              m.Int == dto.Int
                              && m.StrNull == null
                              && m.StrEmpty == null
                              && m.StrAny == dto.StrAny);
            }
        }
    }
