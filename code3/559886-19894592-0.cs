        public static string FractionPart(this double instance)
        {
            var result = string.Empty;
            var ic = CultureInfo.InvariantCulture;
            var splits = instance.ToString(ic).Split(new[] { ic.NumberFormat.NumberDecimalSeparator }, StringSplitOptions.RemoveEmptyEntries);
            if (splits.Count() > 1)
            {
                result = splits[1];
            }
            return result;
        }
