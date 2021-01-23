	public static partial class MartinMulderExtensions {
		public static IEnumerable<Type> GetMscorlibTypes() {
			return
				from assembly in AppDomain.CurrentDomain.GetAssemblies()
				let name=assembly.ManifestModule.Name
				where 0==String.Compare("mscorlib.dll", name, true)
				from type in assembly.GetTypes()
				select type;
		}
	}
