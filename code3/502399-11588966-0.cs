			/// <summary>
			/// Initializes a new instance of the <see cref="OperationWorkflowManagerDomain"/> class.
			/// </summary>
			/// <param name="requestHandlerId">The request handler id.</param>
			public OperationWorkflowManagerDomain(Guid requestHandlerId)
			{
				// Cache the id and download dependent assemblies
				RequestHandlerId = requestHandlerId;
				DownloadAssemblies();
				if (!IsIsolated)
				{
					Domain = AppDomain.CurrentDomain;
					_manager = new OperationWorkflowManager(requestHandlerId);
				}
				else
				{
					// Build list of assemblies that must be loaded into the appdomain
					List<string> assembliesToLoad = new List<string>(ReferenceAssemblyPaths);
					assembliesToLoad.Add(Assembly.GetExecutingAssembly().Location);
					// Create new application domain
					// NOTE: We do not extend the configuration system
					//	each app-domain reuses the app.config for the service
					//	instance - for now...
					string appDomainName = string.Format(
						"Aero Operations Workflow Handler {0} AppDomain",
						requestHandlerId);
					AppDomainSetup ads =
						new AppDomainSetup
						{
							AppDomainInitializer = new AppDomainInitializer(DomainInit),
							AppDomainInitializerArguments = assembliesToLoad.ToArray(),
							ApplicationBase = AppDomain.CurrentDomain.BaseDirectory,
							PrivateBinPathProbe = null,
							PrivateBinPath = PrivateBinPath,
							ApplicationName = "Aero Operations Engine",
							ConfigurationFile = Path.Combine(
								AppDomain.CurrentDomain.BaseDirectory, "ZenAeroOps.exe.config")
						};
					// TODO: Setup evidence correctly...
					Evidence evidence = AppDomain.CurrentDomain.Evidence;
					Domain = AppDomain.CreateDomain(appDomainName, evidence, ads);
					// Create app-domain variant of operation workflow manager
					// TODO: Handle lifetime leasing correctly
					_managerProxy = (OperationWorkflowManagerProxy)Domain.CreateInstanceAndUnwrap(
						Assembly.GetExecutingAssembly().GetName().Name,
						typeof(OperationWorkflowManagerProxy).FullName);
					_proxyLease = (ILease)_managerProxy.GetLifetimeService();
					if (_proxyLease != null)
					{
						//_proxyLease.Register(this);
					}
				}
			}
