    public class MovieModelBinder : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			var modelBinder = new DefaultModelBinder();
			var movie = modelBinder.BindModel(controllerContext, bindingContext) as Movie;
			var id = controllerContext.HttpContext.Request.Form["Id"];
			if (movie != null)
			{
				movie.Id = new ObjectId(id);
				return movie ;
			}
			return null;
		}
	}
