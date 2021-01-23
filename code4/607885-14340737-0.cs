    System.Text.StringBuilder.AppendFormat(IFormatProvider provider, String format, Object[] args) +10610374
    System.String.Format(IFormatProvider provider, String format, Object[] args) +63
    System.Data.EntityRes.GetString(String name, Object[] args) +363
    System.Data.Entity.Strings.ELinq_UnsupportedConstant(Object p0) +95
    System.Data.Objects.ELinq.ConstantTranslator.TypedTranslate(ExpressionConverter parent, ConstantExpression linq) +1256
    System.Data.Objects.ELinq.TypedTranslator`1.Translate(ExpressionConverter parent, Expression linq) +88
    System.Data.Objects.ELinq.ExpressionConverter.TranslateExpression(Expression linq) +162
    System.Data.Objects.ELinq.ContainsTranslator.TranslateContains(ExpressionConverter parent, Expression sourceExpression, Expression valueExpression) +136
    System.Data.Objects.ELinq.MethodCallTranslator.TypedTranslate(ExpressionConverter parent, MethodCallExpression linq) +1011
