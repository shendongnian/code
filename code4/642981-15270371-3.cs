    public static T Convert<T>(IConvertible value, ParserCondition? parserCondition, bool throwOnValidation)
                where T : IComparable<T>
            {
                T convertedValue;
                try
                {
                    convertedValue = (T)value.ToType(typeof(T), null);
                }
                catch (Exception ex)
                {
                    if (throwOnValidation)
                        throw new ArgumentOutOfRangeException(ex.Message, ex);
                    else
                        return default(T);
                }
                return ValidateParserCondition<T>(convertedValue, parserCondition, throwOnValidation);
            }
