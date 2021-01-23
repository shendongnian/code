    public class MustBeListAndContainAttribute : ValidationAttribute
    {
        private Regex regex = null;
        public bool RemoveDuplicates { get; }
        public string Separator { get; }
        public int MinimumItems { get; }
        public int MaximumItems { get; }
        public MustBeListAndContainAttribute(string regexEachItem,
            int minimumItems = 1,
            int maximumItems = 0,
            string separator = ",",
            bool removeDuplicates = false) : base()
        {
            this.MinimumItems = minimumItems;
            this.MaximumItems = maximumItems;
            this.Separator = separator;
            this.RemoveDuplicates = removeDuplicates;
            if (!string.IsNullOrEmpty(regexEachItem))
                regex = new Regex(regexEachItem, RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var listOfdValues = (value as List<string>)?[0];
            if (string.IsNullOrWhiteSpace(listOfdValues))
            {
                if (MinimumItems > 0)
                    return new ValidationResult(this.ErrorMessage);
                else
                    return null;
            };
            var list = new List<string>();
            list.AddRange(listOfdValues.Split(new[] { Separator }, System.StringSplitOptions.RemoveEmptyEntries));
            if (RemoveDuplicates) list = list.Distinct().ToList();
            var prop = validationContext.ObjectType.GetProperty(validationContext.MemberName);
            prop.SetValue(validationContext.ObjectInstance, list);
            value = list;
            if (regex != null)
                if (list.Any(c => string.IsNullOrWhiteSpace(c) || !regex.IsMatch(c)))
                    return new ValidationResult(this.ErrorMessage);
            return null;
        }
    }
