    private static T ValidateParserCondition<T>(T value, ParserCondition? parserCondition, bool throwOnValidation)
        where T : IComparable<T>
    {
        if (parserCondition == null)
            return value;
        else
        {
            int comparingToZero = value.CompareTo(default(T));
            switch (parserCondition.Value)
            {
                case ParserCondition.GreaterOrEqualToZero:
                    if (comparingToZero >= 0)
                        return value;
                    break;
                case ParserCondition.GreaterThanZero:
                    if (comparingToZero > 0)
                        return value;
                    break;
                case ParserCondition.LessOrEqualToZero:
                    if (comparingToZero <= 0)
                        return value;
                    break;
                case ParserCondition.LessThanZero:
                    if (comparingToZero < 0)
                        return value;
                    break;
                default:
                    throw new NotImplementedException("ParserCondition at ValidateParserCondition");
            }
            if (throwOnValidation)
                throw new ArgumentOutOfRangeException(
                    string.Format("value {0} not in accordance with ParserCondition {1}",
                    value, parserCondition.Value.ToString()));
            else
                return default(T);
        }
    }
