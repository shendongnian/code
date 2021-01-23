			private static void DomainInit(string[] args)
			{
				foreach (string arg in args)
				{
					// Treat each string as an assembly to load
					AssemblyName an = AssemblyName.GetAssemblyName(arg);
					AppDomain.CurrentDomain.Load(an);
				}
			}
