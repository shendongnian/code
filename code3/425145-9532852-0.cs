	public class Global : umbraco.Global
	{
		protected override void Application_Start(object sender, System.EventArgs e)
		{
			base.Application_Start(sender, e);
			XmlConfigurator.Configure();
			ILog log = LogManager.GetLogger(typeof (Global));
			log.Debug("Application started");
		}
	}
