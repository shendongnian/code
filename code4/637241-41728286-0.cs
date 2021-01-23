    public static DataTable ToDataTable<T>(this IList<T> lst, bool includeAll = true)
    {
        DataTable dt = new DataTable();
        DataColumn dc;
        PropertyDescriptor pd;
        bool Browsable;
    
        PropertyDescriptorCollection propCol = TypeDescriptor.GetProperties(typeof(T));
                   
        for (int n = 0; n < propCol.Count; n++)
        {
            pd = propCol[n];
            Type propT = pd.PropertyType;
                            
            dc = new DataColumn(pd.Name);
    
            // if Nullable, get underlying type
            // the first test may not be needed
            if (propT.IsGenericType && Nullable.GetUnderlyingType(propT) != null )
            {
                propT = Nullable.GetUnderlyingType(propT);
                dc.DataType = propT;
                dc.AllowDBNull = true;
            }
            else
            {
                dc.DataType = propT;
                dc.AllowDBNull = false;
            }
    
            // is it readonly?
            if (pd.Attributes[typeof(ReadOnlyAttribute)] != null)
            {
                dc.ReadOnly = ((ReadOnlyAttribute)pd.
                         Attributes[typeof(ReadOnlyAttribute)]).IsReadOnly;
            }         
       
            // DefaultValue ...
            if (pd.Attributes[typeof(DefaultValueAttribute)] != null)
            {
                dc.DefaultValue = ((DefaultValueAttribute)pd.
                       Attributes[typeof(DefaultValueAttribute)]).Value;
            }
    
            // caption / display name
            if (pd.Attributes[typeof(DisplayNameAttribute)] != null)
            {
                string theName = ((DisplayNameAttribute)pd.
                       Attributes[typeof(DisplayNameAttribute)]).DisplayName;
                dc.Caption = string.IsNullOrEmpty(theName) ? dc.Caption : theName;
                // DGV doesnt use Caption...save for later
                dc.ExtendedProperties.Add("DisplayName", dc.Caption);
            }
    
            Browsable = true;           
            dc.ExtendedProperties.Add("Browsable", Browsable);
            // seems to exist by default
            if (pd.Attributes[typeof(BrowsableAttribute)] != null) 
            {
                Browsable = ((BrowsableAttribute)pd.Attributes[typeof(BrowsableAttribute)]).Browsable;
                // no such thing as a NonBrowsable DataColumn
                dc.ExtendedProperties["Browsable"] = Browsable;
            }
    
            // ToDo: add support for custom attributes
    
            if (includeAll || Browsable)
            {
                dt.Columns.Add(dc);
            }
        }
                   
        // the lst could be empty - just create the table
        if (lst.Count > 0 && lst[0] is IDataValuesProvider)
        {
            IDataValuesProvider dvp;
            
            // copy the data - let the class do the work
            foreach (T item in lst)
            { 
                dvp = (IDataValuesProvider)item;
                dt.Rows.Add(dvp.GetDataValues(includeAll).ToArray());
            }
        }
        return dt;
    }
