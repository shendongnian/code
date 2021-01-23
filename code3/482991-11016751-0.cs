    namespace ExtensionMethods
    {
        public static class MyExtensions
        {
            public static void SetEncryptColumn(this DataSetType.DataTableRow row, string value)
            {
                row.Encrypt = EncryptValue(value);
            }
            public static string GetEncryptColumn(this DataSetType.DataTableRow row)
            {
                return DecryptValue(row.Encrypt);
            }
        }   
    }
