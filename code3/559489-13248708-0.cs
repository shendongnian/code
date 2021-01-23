    public ServiceResponseBase GetProduct(string productCode)
          {
            object obj = _WebServiceAssembly.CreateInstance("RegisteryService");
            Type typ = obj.GetType();
            object o = typ.InvokeMember("GetProduct", System.Reflection.BindingFlags.InvokeMethod, null, obj, new object[] { productCode });
            return InstantiateObject<ProductResponse>(o);
          }
    private T InstantiateObject<T>(object o) where T : class
          {
            Type t = o.GetType();
            object r = Activator.CreateInstance(typeof(T));
            foreach (System.Reflection.PropertyInfo p in t.GetProperties()) r.GetType().GetProperty(p.Name).SetValue(r, p.GetValue(o, null), null);
            return (T)r;
          }
