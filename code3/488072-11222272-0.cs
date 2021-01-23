      class ConstExpressionBuilder : ExpressionBuilder {
           override bool SupportsEvaluate { get { return true; } }
           override CodeExpression GetCodeExpression(BoundPropertyEntry entry, ...) {
               return new CodeSnippetExpression(entry.Expression);
           }
           override object EvaluateExpression(BoundPropertyEntry entry, ...) {
               var splitExpression = entry.Expression.Split('.');
               var fieldName = splitExpression.Last();
               var typeName = entry.Expression.Substring(entry.Expression.Length - fieldName.Length - 1);
               var type = Type.GetType(typeName);
               return type.GetField(fieldName).GetValue(null);
           }
      }
