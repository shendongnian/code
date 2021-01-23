	public partial class ProxyOfClass {
		public delegate object Method(params object[] args);
		static Dictionary<String, MethodInfo> miDic;
		public Method this[String methodName] {
			get {
				return new Method(args => miDic[methodName].Invoke(m_Instance, args));
			}
		}
		public static void InitializeWithAssembly(String path, String className) {
			var asm=Assembly.LoadFrom(path);
			var type=asm.GetType(className);
			miDic=type.GetMethods().ToDictionary(x => x.Name, x => x);
		}
		public ProxyOfClass(object instance) {
			m_Instance=instance;
		}
		object m_Instance;
	}
