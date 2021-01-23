    Mapper.CreateMap<AViewModel, AEntity>()
          .IgnoreMembers(ignoreMembers)
          .ForAllMembers(o => {
              o.Condition(ctx => {
                    AViewModel instance = (AViewModel)ctx.Parent.SourceValue;
                    return "Id" == ctx.MemberName;
        });
       });
