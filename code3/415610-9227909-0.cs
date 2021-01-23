    public class MaximumOneTimeLimitCanBeCheckedAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as IEnumerable<URLTimeLimitViewModel>;
            if (list == null)
            {
                return true;
            }
            return list.Where(x => x.IsChecked).Count() < 2;
        }
    }
