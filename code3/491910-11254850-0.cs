    public static class FamilyTreeExtension
        {
            public static string GetFamilyTree(this Type t)
            {
                return GetFamilyTreeRecursive(t, t.Name);
            }
    
            public static string GetFamilyTreeRecursive(Type t, string leaf)
            {
                Type baseType = t.BaseType;
    
                string currentTree;
    
                if (baseType != null)
                {
                    currentTree = string.Format("{0}.{1}", baseType.Name, leaf);
                    return GetFamilyTreeRecursive(baseType, currentTree);
                }
                else
                {
                    return leaf;
                }
            }
        }
