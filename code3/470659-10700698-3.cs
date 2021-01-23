	public class InitialisePluginsAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			CompositionBatch compositionBatch = new CompositionBatch();
			compositionBatch.AddPart(filterContext.Controller);
			UniversalCompositionContainer.Current.Container.Compose(
				compositionBatch);
			base.OnActionExecuting(filterContext);
		}
	}
