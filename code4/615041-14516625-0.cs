            Mapper.CreateMap<DtoInfo, Info>().ForMember(info => info.ArtificialPerson, configExpr => 
            { 
                configExpr.MapFrom(dtoInfo => dtoInfo.FullName);
                configExpr.Condition((DtoInfo dtoInfo) => dtoInfo.IsLegal);
            });
            var info1 = Mapper.Map<Info>(new DtoInfo
            {
                FullName = "Lemons",
                IsLegal = true
            });
            Console.WriteLine(info1.ArtificialPerson); // displays "Lemons"
            var info2 = Mapper.Map<Info>(new DtoInfo
            {
                FullName = "Cocaine",
                IsLegal = false
            });
            Console.WriteLine(info2.ArtificialPerson); // displays null string
