    public static T DeepCopy<T>(this T parent) where T : new()
    {
        var newParent = new T();
        foreach (FieldInfo p in typeof(T).GetFields())
        {
            if (p.Name.ToLower() != "id")
                p.SetValue(newParent, p.GetValue(parent));
            else
                p.SetValue(newParent, 0);
            if (p.FieldType.IsGenericType &&
                p.FieldType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                dynamic children = p.GetValue(parent);
                dynamic newChildren = p.GetValue(parent);
                for (int i = 0; i < children.Length; i++)
                {
                    var newChild = DeepCopy(children[i]);
                    newChildren.SetValue(newChild, i);
                }
            }
        }
        return newParent;
    }
