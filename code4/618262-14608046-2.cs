	public partial class ProxyOfClass {
		public delegate object Method(params object[] args);
		static Dictionary<String, MethodInfo> miDic;
		public static void InitializeWithAssembly(String path, String className) {
			var asm=Assembly.LoadFrom(path);
			var type=asm.GetType(className);
			miDic=type.GetMethods().ToDictionary(x => x.Name, x => x);
		}
		public Method this[String methodName] {
			get {
				if(!m_Methods.ContainsKey(methodName))
					m_Methods.Add(methodName, args => miDic[methodName].Invoke(m_Instance, args));
				return m_Methods[methodName];
			}
		}
		public ProxyOfClass(object instance) {
			m_Instance=instance;
		}
		Dictionary<String, Method> m_Methods=new Dictionary<String, Method>();
		object m_Instance;
	}
