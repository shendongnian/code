    public class SettingsExpressionBuilder : System.Web.Compilation.ExpressionBuilder
    {
        public override System.CodeDom.CodeExpression GetCodeExpression(System.Web.UI.BoundPropertyEntry entry, object parsedData, System.Web.Compilation.ExpressionBuilderContext context)
        {
            // here is where the magic happens that tells the compiler
            // what to do with the expression it found.
            // in this case we return a CodeMethodInvokeExpression that
            // makes the compiler insert a call to our custom method
            // 'GetValueFromKey'
            CodeExpression[] inputParams = new CodeExpression[] {
                new CodePrimitiveExpression(entry.Expression.Trim()), 
                new CodeTypeOfExpression(entry.DeclaringType), 
                new CodePrimitiveExpression(entry.PropertyInfo.Name)
            };
            return new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression(
                    this.GetType()
                ),
                "GetValueFromKey",
                inputParams
            );
        }
        public static object GetValueFromKey(string key, Type targetType, string propertyName)
        {
            // here is where you take the provided key and find the corresponding value to return.
            // in this trivial sample, the key itself is returned.
            return key;
        }
    }
