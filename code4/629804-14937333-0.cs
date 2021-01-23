    public Object Convert(Object[] values, Type targetType, Object parameter, CultureInfo culture)
    {
        try
        {
            String text = parameter.ToString();
            IExpression expression = null;
            if (!m_Expressions.TryGetValue(text, out expression))
                m_Expressions[text] = expression = m_Parser.Parse(text);
            Decimal result = expression.Eval(values);
            if (targetType == typeof(Decimal))
                return result;
            if (targetType == typeof(Double))
                return (Double)result;
            if (targetType == typeof(Int32))
                return (Int32)result;
            if (targetType == typeof(Int64))
                return (Int64)result;
            if (targetType == typeof(String))
                return result.ToString();
        }
        catch { }
        return DependencyProperty.UnsetValue;
    }
