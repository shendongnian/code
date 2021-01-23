    public static class StrategyExtensions
    {
        public static Strategy[] GetAllStrategies()
        {
            var statics = typeof (Strategy).GetFields(BindingFlags.Static | BindingFlags.Public);
            var strategies = statics.Where(f => f.FieldType == typeof (Strategy));
            var values = strategies.Select(s => s.GetValue(null));
            return values.Cast<Strategy>().ToArray();
        }
    }
