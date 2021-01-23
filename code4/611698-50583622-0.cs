	public class CustomBootstrapper : DefaultNancyBootstrapper
	{
		protected override void ConfigureConventions(NancyConventions nancyConventions)
		{
			base.ConfigureConventions(nancyConventions);
			nancyConventions.StaticContentsConventions.Add(
    #if (DEBUG)
				UnsafeStaticContentConventionBuilder.AddDirectory("/StaticContent", "../../StaticContent")
    #else
				StaticContentConventionBuilder.AddDirectory("/StaticContent", "StaticContent")
    #endif
				);
		}
	}
