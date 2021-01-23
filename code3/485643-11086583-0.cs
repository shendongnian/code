    Mapper.CreateMap<Entity, EntityViewModel>()
          .AfterMap((src, dest) => { 
              if (dest.Timings == null) {
                  // Populate default values
              }
              else if (dest.Timings.Count < 7) {
                  // Populate the rest of the values
              }
           });
