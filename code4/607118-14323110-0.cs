     public class CustomResolver : ValueResolver<UpdateEmployeeDetailsDto, List<string>>
      {
      	protected override List<string> ResolveCore(UpdateEmployeeDetailsDto source)
      	{
      		return new List<string> { source.EmailAddress1, source.EmailAddress2 }
      	}
      }
    Mapper.CreateMap<UpdateEmployeeDetailsDto, Employee>()
  	  .ForMember(dest => dest.EmailAddresses, opt => opt.ResolveUsing<CustomResolver>());
