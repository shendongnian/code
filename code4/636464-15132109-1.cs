    public static class CodeContractsExtensions
    {
        public static void DisableInvariantEvaluation(this object entity)
        {
            var evaluatingInvariantField = entity.GetType()
                                                 .GetField(
                                                     "$evaluatingInvariant$", 
                                                     BindingFlags.NonPublic | 
                                                     BindingFlags.Instance);
            if (evaluatingInvariantField == null)
                return;
            evaluatingInvariantField.SetValue(entity, true);
        }
        public static void EnableInvariantEvaluation(this object entity,
                                                     bool evaluateNow)
        {
            var evaluatingInvariantField = entity.GetType()
                                                 .GetField(
                                                     "$evaluatingInvariant$", 
                                                     BindingFlags.NonPublic | 
                                                     BindingFlags.Instance);
            if (evaluatingInvariantField == null)
                return;
            evaluatingInvariantField.SetValue(entity, false);
            if (!evaluateNow)
                return;
            var invariantMethod = entity.GetType()
                                        .GetMethod("$InvariantMethod$",
                                                   BindingFlags.NonPublic | 
                                                   BindingFlags.Instance);
            if (invariantMethod == null)
                return;
            invariantMethod.Invoke(entity, new object[0]);
        }
    }
