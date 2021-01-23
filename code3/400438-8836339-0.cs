    public ObjectResult<***SomeType***> GetValues(string uRL, PortalConstant.DataSourceType DataSourceType)
    {
        ObjectResult<***SomeType***> ret = null;
        var dataPlugin = DataPlugins.FirstOrDefault(i => i.Metadata["SQLMetaData"].ToString() == DataSourceType.EnumToString());
        if (dataPlugin != null)
        {
            ret = dataPlugin.Value.***SomeMethod***(uRL);
        }
        return ret;
    }
