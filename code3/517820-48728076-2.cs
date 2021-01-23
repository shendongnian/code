    private InvokeNamespaceClassStaticMethodResult[] _InvokeNamespaceClassStaticMethod(string namespaceName, string methodName, bool throwExceptions, params object[] parameters) {
    	var results = new List<InvokeNamespaceClassStaticMethodResult>();
    	foreach(var _a in AppDomain.CurrentDomain.GetAssemblies()) {
    		foreach(var _t in _a.GetTypes()) {
    			if((_t.Namespace == namespaceName) && _t.IsClass) {
    				var method_t = _t.GetMethod(methodName, parameters.Select(_ => _.GetType()).ToArray());
    				if((method_t != null) && method_t.IsPublic && method_t.IsStatic) {
    					var details_t = new InvokeNamespaceClassStaticMethodResult();
    					details_t.Namespace = _t.Namespace;
    					details_t.Class = _t.Name;
    					details_t.Method = method_t.Name;
    					try {
    						if(method_t.ReturnType == typeof(void)) {
    							method_t.Invoke(null, parameters);
    							details_t.Void = true;
    						} else {
    							details_t.Return = method_t.Invoke(null, parameters);
    						}
    					} catch(Exception ex) {
    						if(throwExceptions) {
    							throw;
    						} else {
    							details_t.Exception = ex;
    						}
    					}
    					results.Add(details_t);
    				}
    			}
    		}
    	}
    	return results.ToArray();
    }
    
    private class InvokeNamespaceClassStaticMethodResult {
    	public string Namespace;
    	public string Class;
    	public string Method;
    	public object Return;
    	public bool Void;
    	public Exception Exception;
    }
