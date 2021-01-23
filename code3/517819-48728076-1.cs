	private void _InvokeNamespaceClassesStaticMethod(string namespaceName, string methodName, params object[] parameters) {
       	foreach(var _a in AppDomain.CurrentDomain.GetAssemblies()) {
   			foreach(var _t in _a.GetTypes()) {
                try {
      				if((_t.Namespace == namespaceName) && _t.IsClass) _t.GetMethod(methodName, (BindingFlags.Static | BindingFlags.Public))?.Invoke(null, parameters);
                } catch { }
   			}
   		}
   	}
