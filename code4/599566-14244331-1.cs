        public static Type FindEqualTypeWith(this Type typeLeft, Type typeRight)
        {
            if (typeLeft == null || typeRight == null) return null;
           return typeLeft
                .GetInterfaceHierarchy().Union(typeLeft.GetClassHierarchy())
                .Intersect(typeRight.GetInterfaceHierarchy().Union(typeRight.GetClassHierarchy()))
                .OrderByDescending(interfaceinHierarhy => interfaceinHierarhy.GetInterfaces().Contains(typeof(IEnumerable)))
                .ThenByDescending(interfaceinHierarhy => interfaceinHierarhy.Equals(typeof(IEnumerable)))
                .FirstOrDefault();
        }
