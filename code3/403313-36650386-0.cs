     public static T ToModel<T>(this Person entity)
     {
          Type typeParameterType = typeof(T);
    
          if(typeParameterType == typeof(PersonView))
          {
              Mapper.CreateMap<Person, PersonView>();
              return Mapper.Map<T>(entity);
          }
    
          return default(T);
     }
