    CustomFieldDataSet cfDS = new CustomFieldDataSet();
    PSLibrary.Filter cfFilter = new Microsoft.Office.Project.Server.Library.Filter();
    cfFilter.FilterTableName = cfDS.CustomFields.TableName;
    cfFilter.Fields.Add(new PSLibrary.Filter.Field(cfDS.CustomFields.TableName, cfDS.CustomFields.MD_PROP_NAMEColumn.ColumnName));
    cfFilter.Fields.Add(new PSLibrary.Filter.Field(cfDS.CustomFields.TableName, cfDS.CustomFields.MD_PROP_IDColumn.ColumnName));
    cfFilter.Fields.Add(new PSLibrary.Filter.Field(cfDS.CustomFields.TableName, cfDS.CustomFields.MD_PROP_UIDColumn.ColumnName));
    cfFilter.Fields.Add(new PSLibrary.Filter.Field(cfDS.CustomFields.TableName, cfDS.CustomFields.MD_LOOKUP_TABLE_UIDColumn.ColumnName));
    cfFilter.Fields.Add(new PSLibrary.Filter.Field(cfDS.CustomFields.TableName, cfDS.CustomFields.MD_PROP_TYPE_ENUMColumn.ColumnName));
    cfDS = ReadCustomFields(cfFilter.GetXml(), false);
