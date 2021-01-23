    public void ReflectionMagic(Object obj)
        {
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static;
            Type webview_type = obj.GetType();
            ConstructorInfo[] constructorinfo_arr = webview_type.GetConstructors(flags);
            MemberInfo[] memberinfo_arr = webview_type.GetDefaultMembers();
            EventInfo[] eventinfo_arr = webview_type.GetEvents(flags);
            FieldInfo[] fieldinfo_arr = webview_type.GetFields(flags);
            Type[] interfaces_arr = webview_type.GetInterfaces();
            MemberInfo[] membersinfo_arr = webview_type.GetMembers(flags);
            MethodInfo[] methodinfo_arr = webview_type.GetMethods(flags);
            Type[] nestedtypes_arr = webview_type.GetNestedTypes(flags);
            PropertyInfo[] propertyinfo_arr = webview_type.GetProperties(flags);
            Type webview_interface_type = obj.GetType().GetInterfaces()[5].GetType();
            ConstructorInfo[] constructorinfo_arr2 = webview_interface_type.GetConstructors(flags);
            MemberInfo[] memberinfo_arr2 = webview_interface_type.GetDefaultMembers();
            EventInfo[] eventinfo_arr2 = webview_interface_type.GetEvents(flags);
            FieldInfo[] fieldinfo_arr2 = webview_interface_type.GetFields(flags);
            Type[] interfaces_arr2 = webview_interface_type.GetInterfaces();
            MemberInfo[] membersinfo_arr2 = webview_interface_type.GetMembers(flags);
            MethodInfo[] methodinfo_arr2 = webview_interface_type.GetMethods(flags);
            Type[] nestedtypes_arr2 = webview_interface_type.GetNestedTypes(flags);
            PropertyInfo[] propertyinfo_arr2 = webview_interface_type.GetProperties(flags);
        }
