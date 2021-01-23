        public static class AxaptaExtensions
        {
            public static int GetTableId(this Axapta ax, string table)
            {
                return (int)ax.CallStaticClassMethod("Global", "tableName2Id", table);
            }
        }
