    var dataSourceType = typeof(DataSource).Assembly.GetType("DataSource", true);
    var datafield = Activator.CreateInstance(dataSourceType);
    PropertyInfo pinfo = datafield.GetType().GetProperty("Parameters");
    ParameterCollection parmCollection = new ParameterCollection();
    QueryStringParameter myParm = new QueryStringParameter("ber", DbType.String, "ber");
    parmCollection.Add(myParm);
    pinfo.SetValue(datafield, parmCollection, null);
