[SQLiteFunction(FuncType = FunctionType.Collation, Name = "UTF8CI")]
    public class SQLiteCaseInsensitiveCollation : SQLiteFunction
    {
        private static readonly System.Globalization.CultureInfo _cultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture("tr-TR");
        public override int Compare(string x, string y)
        {
            return string.Compare(x, y, _cultureInfo, System.Globalization.CompareOptions.IgnoreCase);
        }
    }
