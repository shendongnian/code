    private string ToCsv(string separator, IEnumerable<object> objectList)
    {
        StringBuilder csvData = new StringBuilder();
        foreach (var obj in objectList)
        {
            csvData.AppendLine(ToCsvFields(separator, obj));
        }
        return csvData.ToString();
    }
    private string ToCsvFields(string separator, object obj)
    {
        var fields = obj.GetType().GetProperties();
        StringBuilder line = new StringBuilder();
        if (obj is string)
        {
            line.Append(obj as string);
            return line.ToString();
        }
        foreach (var field in fields)
        {
            var value = field.GetValue(obj);
            var fieldType = field.GetValue(obj).GetType();
            if (line.Length > 0)
            {
                line.Append(separator);
            }
            if (value == null)
            {
                line.Append("NULL");
            }
            if (value is string)
            {
                line.Append(value as string);
            }
            if (typeof(IEnumerable).IsAssignableFrom(fieldType))
            {
                var objectList = value as IEnumerable;
                StringBuilder row = new StringBuilder();
                foreach (var item in objectList)
                {
                    if (row.Length > 0)
                    {
                        row.Append(separator);
                    }
                    row.Append(ToCsvFields(separator, item));
                }
                line.Append(row.ToString());
            }
            else
            {
                line.Append(value.ToString());
            }
        }
        return line.ToString();
    }
