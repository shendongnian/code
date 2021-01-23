    public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
    {
        if (indexes.Length != 1 || !(indexes[0] is string))
        {
            result = null;
            return false;
        }
        result = _xml.Attribute(indexes[0] as string);
        return result != null;
    }
