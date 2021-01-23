    public bool SetPropertyValue(object obj, string prop, object value) {
        var item = obj.GetType().BaseType.GetProperty(prop, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        //MessageBox.Show(obj.ToString());
        if (item != null) {
            item.SetValue(obj, value);
            return true;
        }
            
        return false;
    }
