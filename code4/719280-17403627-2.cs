    public bool SetPropertyValue(object obj, string prop, object value) {
        var item = GetBaseType(obj.GetType()).GetProperty(prop, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        //MessageBox.Show(obj.ToString());
        if (item != null) {
            item.SetValue(obj, value);
            return true;
        }
        return false;
    }
    public Type GetBaseType(Type type) {
        if (type.BaseType != typeof(object)) {
            return GetBaseType(type.BaseType);
        }
        return type;
    }
