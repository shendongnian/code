    public dynamic TestLinq(IEnumerable<Data> data, IEnumerable<string> properties)
    {
        // Validate parameters.
        if (properties == null) throw new ArgumentNullException("properties");
        if (data == null) throw new ArgumentNullException("data");
        // Construct the field list.
        var fields = new StringBuilder();
        foreach (string p in properties) fields.AppendFormat("{0},", property);
    
        // Throw an exception if there are no items.
        if (fields.Length == 0) throw new ArgumentException(
            "The properties enumeration contains no elements.", "properties");
        // Remove the last comma.
        fields.Length--;
        // Select the items and return.  Create the
        // projection here.
        return data.Select("new(" + fields + ")");
    }
