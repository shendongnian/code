			private void DownloadAssemblies()
			{
				List<string> refAssemblyPathList = new List<string>();
				using (ZenAeroOpsEntities context = new ZenAeroOpsEntities())
				{
					DbRequestHandler dbHandler = context
						.DbRequestHandlers
						.Include("ReferenceAssemblies")
						.FirstOrDefault((item) => item.RequestHandlerId == RequestHandlerId);
					if (dbHandler == null)
					{
						throw new ArgumentException(string.Format(
							"Request handler {0} not found.", RequestHandlerId), "requestWorkflowId");
					}
					// If there are no referenced assemblies then we can host
					//	in the main app-domain
					if (dbHandler.ReferenceAssemblies.Count == 0)
					{
						IsIsolated = false;
						ReferenceAssemblyPaths = new string[0];
						return;
					}
					// Create folder
					if (!Directory.Exists(PrivateBinPath))
					{
						Directory.CreateDirectory(PrivateBinPath);
					}
					// Download assemblies as required
					foreach (DbRequestHandlerReferenceAssembly dbAssembly in dbHandler.ReferenceAssemblies)
					{
						AssemblyName an = new AssemblyName(dbAssembly.AssemblyName);
						// Determine the local assembly path
						string assemblyPathName = Path.Combine(
							PrivateBinPath,
							string.Format("{0}.dll", an.Name));
						// TODO: If the file exists then check it's SHA1 hash
						if (!File.Exists(assemblyPathName))
						{
							// TODO: Setup security descriptor
							using (FileStream stream = new FileStream(
								assemblyPathName, FileMode.Create, FileAccess.Write))
							{
								stream.Write(dbAssembly.AssemblyPayload, 0, dbAssembly.AssemblyPayload.Length);
							}
						}
						refAssemblyPathList.Add(assemblyPathName);
					}
				}
				ReferenceAssemblyPaths = refAssemblyPathList.ToArray();
				IsIsolated = true;
			}
