    	public void AppStartup(object sender, StartupEventArgs e) {
			if (AppDomain.CurrentDomain.IsDefaultAppDomain()) {
				string appName = AppDomain.CurrentDomain.FriendlyName;
				var currentAssembly = Assembly.GetExecutingAssembly();
				// Setup path to application config file in ./Config dir:
				AppDomainSetup setup = new AppDomainSetup();
				setup.ApplicationBase = System.Environment.CurrentDirectory;
				setup.ConfigurationFile = setup.ApplicationBase + 
									string.Format("\\Config\\{0}.config", appName);
				// Create a new app domain using setup with new config file path:
				AppDomain newDomain = AppDomain.CreateDomain("NewAppDomain", null, setup);
				int ret = newDomain.ExecuteAssemblyByName(currentAssembly.FullName, e.Args);
				// Above causes recusive call to this method.
				
				//--------------------------------------------------------------------------//
				AppDomain.Unload(newDomain);
				Environment.ExitCode = ret;
				// We get here when the new app domain we created is shutdown.  Shutdown the 
				// original default app domain (to avoid running app again there):
				// We could use Shutdown(0) but we have to remove the main window uri from xaml
				// and then set it for new app domain (above execute command) using:
				// StartupUri = new Uri("Window1.xaml", UriKind.Relative);
				Environment.Exit(0);
				return;
			}
		}
