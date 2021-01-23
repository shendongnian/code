    public class ClientCourseConverter<TSource, TDestination>: ITypeConverter<TSource, TDestination>
           where TSource :  new()
		   where TDestination : MappedViewModel<TEntity>, new()
    {
      	public TDestination Convert(ResolutionContext context)
    	{
    		var destination = (TDestination)context.DestinationValue;
    		if(destination == null)
    			destination = new TDestination();
    		destination.MapFromEntity((TSource)context.SourceValue);
    	}
    }
    // Mapping configuration
    Mapper.CreateMap<ClientCourse, ClientCourseIndexItem>().ConvertUsing(
     new ClientCourseConverter<ClientCourse, ClientCourseIndexItem>());
