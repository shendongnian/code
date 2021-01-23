    Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args) {
    			Assembly result = null;
    			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) {
    				AssemblyName assemblyName = assembly.GetName();
    				if (args.Name.StartsWith(assemblyName.Name)) {
    					this.LogInfo("Assembly \"" + args.Name + "\" resolved to \"" + assembly.Location + "\".");
    					result = assembly;
    					break;
    				}
    			}
    			if(result != null){
    				return result;
    			}else{
    				this.LogError("Assembly resolution failure. An assembly named \"" + args.Name + "\" was not found.");
    				return null;
    			}
    		}
