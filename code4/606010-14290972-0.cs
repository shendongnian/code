    private List<MemberInfo> GetMembers(Type objectType, MemberTypes memberType)
    {
        List<MemberInfo> members = new List<MemberInfo>();
        Assembly asm = Assembly.GetAssembly(objectType);
        foreach (Type t in asm.GetExportedTypes().Where((Type testType) => object.ReferenceEquals(testType, objectType))) {
            foreach (MemberInfo mi in t.GetMembers().Where((MemberInfo member) => member.MemberType == memberType)) {
                switch (memberType) {
                    case MemberTypes.Property:
                        members.Add(mi);
                        break;
                    case MemberTypes.Method:
                        bool isValid = true;
                        foreach (PropertyInfo pi in t.GetProperties()) {
                            if ((pi.CanWrite && pi.GetSetMethod().Name == mi.Name) || (pi.CanRead && pi.GetGetMethod().Name == mi.Name)) {
                                isValid = false;
                                break;
                            }
                        }
                        if (isValid)
                            members.Add(mi);
                        break;
                }
            }
        }
        return members.OrderBy((MemberInfo mi) => mi.Name).ToList();
    }
