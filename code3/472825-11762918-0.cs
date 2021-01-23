    public static class DataColumnExtensions
    {
        private static readonly Assembly DataAssembly = Assembly.GetAssembly(typeof(DataTable));
        public static bool DependsOn(this DataColumn thisColumn, DataColumn otherColumn)
        {
            if (string.IsNullOrEmpty(thisColumn.Expression))
            {
                return false;
            }
            var dataExpression = DataAssembly.CreateInstance(
                "System.Data.DataExpression",
                false,
                BindingFlags.Default | BindingFlags.CreateInstance | BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                new object[] { thisColumn.Table, thisColumn.Expression, thisColumn.DataType },
                null,
                null);
            var dependsOnMethod = dataExpression.GetType().GetMethod("DependsOn", BindingFlags.NonPublic | BindingFlags.Instance);
            var result = (bool)dependsOnMethod.Invoke(dataExpression, new object[] { otherColumn });
            return result;
        }
    }
