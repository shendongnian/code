    public static class SearchProvider
    {
        static Func<object, bool> GetSearchMethod(SelectorOperator selectorOperator, string conditionFieldValue)
        {
            switch (selectorOperator)
            {
                //strings
                case SelectorOperator.Contains:
                    return new Func<object, bool>(s => s.ToString().ToLower().Contains(conditionFieldValue));
                case SelectorOperator.StartsWith:
                    return new Func<object, bool>(s => s.ToString().ToLower().StartsWith(conditionFieldValue));
                case SelectorOperator.EndsWith:
                    return new Func<object, bool>(s => s.ToString().ToLower().EndsWith(conditionFieldValue));
                case SelectorOperator.Is:
                    return new Func<object, bool>(s => string.Equals(s.ToString(), conditionFieldValue, StringComparison.OrdinalIgnoreCase));
                //numbers
                case SelectorOperator.Equals:
                    return new Func<object, bool>(n => (long)n == long.Parse(conditionFieldValue));
                case SelectorOperator.IsGreaterThan:
                    return new Func<object, bool>(n => (long)n > long.Parse(conditionFieldValue));
                case SelectorOperator.IsLessThan:
                    return new Func<object, bool>(n => (long)n < long.Parse(conditionFieldValue));
                //type
                case SelectorOperator.TypeIs:
                    return new Func<object, bool>(t => (EventLogEntryType)t == (EventLogEntryType)Enum.Parse(typeof(EventLogEntryType), conditionFieldValue));
                case SelectorOperator.TypeIsNot:
                    return new Func<object, bool>(t => (EventLogEntryType)t != (EventLogEntryType)Enum.Parse(typeof(EventLogEntryType), conditionFieldValue));
                default:
                    throw new Exception("Unknown selector operator");
            }
        }
        private static List<EventLogItem> SearchAll(List<EventLogItem> currentLogs, SearchQuery query)
        {
            foreach (SearchCondition condition in query.Conditions)
            {
                var search = GetSearchMethod(condition.SelectorOperator, condition.FieldValue as string);
                switch (condition.FieldName)
                {
                    case FieldItem.Category:
                        currentLogs = currentLogs.Where(item => search(item.Category)).ToList();
                        break;
                    case FieldItem.InstanceID:
                        currentLogs = currentLogs.Where(item => search(item.InstanceID)).ToList();
                        break;
                    case FieldItem.LogName:
                        currentLogs = currentLogs.Where(item => search(item.LogName)).ToList();
                        break;
                    case FieldItem.Message:
                        currentLogs = currentLogs.Where(item => search(item.Message)).ToList();
                        break;
                    case FieldItem.Number:
                        currentLogs = currentLogs.Where(item => search(item.Number)).ToList();
                        break;
                    case FieldItem.Source:
                        currentLogs = currentLogs.Where(item => search(item.Source)).ToList();
                        break;
                    case FieldItem.Type:
                        currentLogs = currentLogs.Where(item => search(item.Type)).ToList();
                        break;
                }
            }
            return currentLogs;
        }
    }
