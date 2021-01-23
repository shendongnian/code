    public class MyEntityToDataTableConvertor : ITypeConvertor<MyEntity, DataTable>
    {
        public DataTable Convert(ResolutionContext context)
        {
            MyEntity myEntity = (MyEntity)context.SourceValue;
            DataTable dt = GetDataTableSchema();
            DataRow nr = dt.NewRow();
            nr["property_column"] = myEntity.Property;
            // and so on
            return dt;
        }
    }
