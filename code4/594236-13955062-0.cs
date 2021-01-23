    GridDataSource.SelectMethod = "GetAllCountries";
     Parameter p1 = new Parameter("PageSize",TypeCode.Int32);
     Parameter p2 = new Parameter("OrderBy",TypeCode.String);
     Parameter p3 = new Parameter("StartIndex",TypeCode.Int32);
     GridDataSource.SelectParameters.Add(p1);
     GridDataSource.SelectParameters.Add(p2);
     GridDataSource.SelectParameters.Add(p3);
