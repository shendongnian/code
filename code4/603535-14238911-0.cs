    object CreateObjectFromNVPair(Container c)
    {
        Type t = Type.GetType(this.GetType().Namespace + "." + c.Type);
        object o = Activator.CreateInstance(t);
        if (c.Attributes != null)
        {
            foreach (Attribute a in c.Attributes)
            {
                PropertyInfo pi = o.GetType().GetProperty(a.Name);
                pi.SetValue(o, a.Value, null);
            }
        }
        if (c.RelatedContainers != null)
        {
            foreach (Container c2 in c.RelatedContainers)
            {
                Type lt = typeof(List<>);
                Type t2 = Type.GetType(this.GetType().Namespace + "." + c2.Type);
                PropertyInfo pi = o.GetType().GetProperty(c2.Type + "List");
                object l = pi.GetValue(o, null);
                if (l == null)
                {
                    l = Activator.CreateInstance(lt.MakeGenericType(new Type[] { t2 }));
                    pi.SetValue(o, l, null);
                }
                object o2 = CreateObjectFromNVPair(c2);
                MethodInfo mi = l.GetType().GetMethod("Add");
                mi.Invoke(l, new object[] { o2 });
            }
        }
        return o;
    }
