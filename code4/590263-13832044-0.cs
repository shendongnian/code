    public class GetClassFields
    {
        public static List<string> AsList(string tbl)
        {
            var instanceOfClass = new HTDB_Cols();
            return typeof(HTDB_Cols).GetNestedTypes()
                                    .First(t => String.Compare(t.Name, tbl, true) == 0)
                                    .GetFields()
                                    .Select(f => f.GetValue(instanceOfClass).ToString())
                                    .ToList<String>();
        }
    }
