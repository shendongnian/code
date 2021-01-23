    foreach (DataTable dt in ds.Tables) {
            foreach (DataColumn dc in dt.Columns) {
                dc.ColumnMapping = MappingType.Attribute;
               //If type is DataType string
               dc.DefaultValue = String.Empty;
            }
