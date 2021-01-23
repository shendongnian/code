    private static object IsAnonymousType(object expected)
    {
        return Match.Create(
            (object actual) =>
            {
                if (expected == null)
                {
                    if (actual == null)
                        return true;
                    else
                        return false;
                }
                else if (actual == null)
                    return false;
                var expectedPropertyNames = expected.GetType().GetProperties().Select(x => x.Name);
                var expectedPropertyValues = expected.GetType().GetProperties().Select(x => x.GetValue(expected, null));
                var actualPropertyNames = actual.GetType().GetProperties().Select(x => x.Name);
                var actualPropertyValues = actual.GetType().GetProperties().Select(x => x.GetValue(actual, null));
                return expectedPropertyNames.SequenceEqual(actualPropertyNames)
                    && expectedPropertyValues.SequenceEqual(actualPropertyValues);
            });
    }
