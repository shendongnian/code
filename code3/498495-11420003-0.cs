    public class ClientCourseConverter: ITypeConverter<ClientCourse, ClientCourseIndexItem>
    {
      	public TDestination Convert(ResolutionContext context)
    	{
    		var destination = (ClientCourseIndexItem)context.Parent.DestinationValue;
    		if(destination == null)
    			destination = new ClientCourseIndexItem();
    		destination.MapFromEntity((ClientCourse)context.SourceValue);
    	}
    }
    // Mapping configuration
    Mapper.CreateMap<ClientCourse, ClientCourseIndexItem>().ConvertUsing(new ClientCourseConverter());
