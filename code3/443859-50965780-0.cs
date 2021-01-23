    public class ListMustContainElementsAttribute : ValidationAttribute
    {
        public ListMustContainElementsAttribute(int MinimumItems = 1, int MaximumItems = 0) : base()
        {
            this.MinimumItems = MinimumItems;
            this.MaximumItems = MaximumItems;
        }
        public int MinimumItems { get; }
        public int MaximumItems { get; }
        public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list == null) return false;
            if (MinimumItems > list.Count) return false;
            if (MaximumItems > 0)
                if (MaximumItems < list.Count) return false;
            return true;
        }
    }
    public class ListMustContainStringElementsAttribute : ListMustContainElementsAttribute
    {
        private Regex regex = null;
        private bool removeDuplicates = false;
        public ListMustContainStringElementsAttribute(string regexEachItem, int MinimumItems = 1, int MaximumItems = 0, bool RemoveDuplicates = false) : base(MinimumItems, MaximumItems)
        {
            regex = new Regex(regexEachItem, RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);
            removeDuplicates = RemoveDuplicates;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var commaSeparatedValues = (value as List<string>)?[0];
            if (string.IsNullOrWhiteSpace(commaSeparatedValues)) return new ValidationResult(this.ErrorMessage);
            var list = new List<string>();
            list.AddRange(commaSeparatedValues.Split(new[] { "," }, System.StringSplitOptions.RemoveEmptyEntries));
            if (removeDuplicates) list = list.Distinct().ToList();
            var prop = validationContext.ObjectType.GetProperty(validationContext.MemberName);
            prop.SetValue(validationContext.ObjectInstance, list);
            value = list;
            if(!base.IsValid(value)) return new ValidationResult(this.ErrorMessage);
            if (regex != null)
                if (list.Any(c => string.IsNullOrWhiteSpace(c) || !regex.IsMatch(c))) return new ValidationResult(this.ErrorMessage);
            return null;
        }
    }
