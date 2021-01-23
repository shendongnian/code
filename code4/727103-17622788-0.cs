	public static void Main()
	{
		Console.WriteLine(Role.GetRole("Admin").Ololo);
	}
	
	public static class AppDomainExtensions {
		public static List<AppDomain> GetAllAppDomains() {
			List<AppDomain> appDomains = new List<AppDomain>();
		
			IntPtr handle = IntPtr.Zero;
			ICorRuntimeHost host = (ICorRuntimeHost)(new CorRuntimeHost());
			try
			{
				host.EnumDomains(out handle);
				while (true)
				{
					object domain;
					host.NextDomain(handle, out domain);
					if (domain == null)
						break;
					appDomains.Add((AppDomain)domain);
				}
			}
			finally
			{
				host.CloseEnum(handle);
			}
			
			return appDomains;
		}
		
		[ComImport]
		[Guid("CB2F6723-AB3A-11d2-9C40-00C04FA30A3E")]
		private class CorRuntimeHost// : ICorRuntimeHost
		{
		}
		
		[Guid("CB2F6722-AB3A-11D2-9C40-00C04FA30A3E")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		private interface ICorRuntimeHost
		{
			void CreateLogicalThreadState ();
			void DeleteLogicalThreadState ();
			void SwitchInLogicalThreadState ();
			void SwitchOutLogicalThreadState ();
			void LocksHeldByLogicalThread ();
			void MapFile ();
			void GetConfiguration ();
			void Start ();
			void Stop ();
			void CreateDomain ();
			void GetDefaultDomain ();
			void EnumDomains (out IntPtr enumHandle);
			void NextDomain (IntPtr enumHandle, [MarshalAs(UnmanagedType.IUnknown)]out object appDomain);
			void CloseEnum (IntPtr enumHandle);
			void CreateDomainEx ();
			void CreateDomainSetup ();
			void CreateEvidence ();
			void UnloadDomain ();
			void CurrentDomain ();
		}   
	}
	
	public abstract class Role
	{
		private static Dictionary<string, Role> Roles = new Dictionary<string, Role>(); 
	
		public static Role GetRole(string key) {
			if (Roles.ContainsKey(key))
				return Roles[key];
			
			foreach (var appDomain in AppDomainExtensions.GetAllAppDomains()) {
				foreach (var assembly in appDomain.GetAssemblies()) {
					var type = assembly.GetTypes().Where(t => t.Name == key + "Role").FirstOrDefault();// (key + "Role", false, true);				
					
					if (type == null || !typeof(Role).IsAssignableFrom(type))
						continue;
					
					Role role = null;
						
					{
						var fieldInfo = type.GetField("Instance", BindingFlags.Static | BindingFlags.Public);
						
						
						if (fieldInfo != null) {
							role = fieldInfo.GetValue(null) as Role;               
						}
						else {
							var propertyInfo = type.GetProperty("Instance", BindingFlags.Static | BindingFlags.Public);
							
							if (propertyInfo != null)
								role = propertyInfo.GetValue(null, null) as Role;
						}
					}
					
					if (role == null)
						continue;
					
					Roles[key] = role;
					
					return role;
				}			
			}
			
			throw new KeyNotFoundException();
		}
		
		public string Ololo {get;set;}
	}
	
	public class AdminRole : Role
	{
		public static readonly AdminRole Instance = new AdminRole();
		
		private AdminRole() {
			Ololo = "a";
		}
		
	}
