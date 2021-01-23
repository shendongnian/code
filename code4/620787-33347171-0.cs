    public static IEnumerable<string> GetPropertInfos(object o, string parent = null)
        {
            
            Type t = o.GetType();
            //   String namespaceValue = t.Namespace;
            PropertyInfo[] props = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prp in props)
            {
                if (prp.PropertyType.Module.ScopeName != "CommonLanguageRuntimeLibrary")
                {
                    // fix me: you have to pass parent + "." + t.Name instead of t.Name if parent != null
                    object value = prp.GetValue(o);
                    if (value == null)
                    {
                        value =
                            Activator.CreateInstance(Type.GetType(
                                (prp.PropertyType).AssemblyQualifiedName.Replace("[]", "")));
                    }
                    var propertInfos = GetPropertInfos(value, t.Name);
                    foreach (var info in propertInfos)
                        yield return info;
                }
                else
                {
                    var type = GetTypeName(prp);
                    var info = t.Name + "." + prp.Name ;
                    if (String.IsNullOrWhiteSpace(parent))
                        yield return info;
                    else
                        yield return parent + "." + info;
                }
            }
        }
