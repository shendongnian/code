    List<PropertyInfo> _propInfo = _row.GetType().GetProperties();
        
        foreach (var item in _propInfo)
        {
        object _value = item.GetValue(_row, null);
        if (_value != null)
        {
        // Save the Value
        }
        }
