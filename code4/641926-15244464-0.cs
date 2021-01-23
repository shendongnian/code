    public override string ToString() {
        PropertyDescriptorCollection coll = TypeDescriptor.GetProperties(this);
        string result = string.Empty;
        foreach(PropertyDescriptor pd in coll)
            result += " " + pd.GetValue(this).ToString();
        return result;
    }
