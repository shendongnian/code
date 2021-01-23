    static void EnumerateObjectsInRange(object root, HashSet<object> hashset)
    {
        if (root == null || hashset.Contains(root))
        {
            return;
        }
        hashset.Add(root);
        FieldInfo[] fields = root.GetType().GetFields(BindingFlags.Static
                                                    | BindingFlags.Instance
                                                    | BindingFlags.Public
                                                    | BindingFlags.NonPublic);
        foreach (FieldInfo field in fields)
        {
            object obj = field.GetValue(root);
            if (obj == null)
            {
                continue;
            }
            if (obj.GetType().IsSubclassOf(typeof(Array)))
            {
                foreach (object member in (Array)obj)
                {
                    EnumerateObjectsInRange(member, hashset);
                }
            }
            EnumerateObjectsInRange(obj, hashset);
        }
    }
