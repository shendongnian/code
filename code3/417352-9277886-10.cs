    public class MyViewModel: IValidatableObject
    {
        public string SelectedOption { get; set; }
        public IEnumerable<SelectListItem> Options
        {
            get
            {
                return new[]
                {
                    new SelectListItem { Value = "1", Text = "item 1" },
                    new SelectListItem { Value = "2", Text = "item 2" },
                };
            }
        }
        public string RadioButtonValue { get; set; }
        public string Input1 { get; set; }
        public string Input2 { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (SelectedOption == "1")
            {
                if (string.IsNullOrEmpty(Input1))
                {
                    yield return new ValidationResult(
                        "Input1 is required", 
                        new[] { "Input1" }
                    );
                }
                if (string.IsNullOrEmpty(Input2))
                {
                    yield return new ValidationResult(
                        "Input2 is required",
                        new[] { "Input2" }
                    );
                }
            }
            else if (SelectedOption == "2")
            {
                if (string.IsNullOrEmpty(RadioButtonValue))
                {
                    yield return new ValidationResult(
                        "RadioButtonValue is required",
                        new[] { "RadioButtonValue" }
                    );
                }
            }
            else
            {
                yield return new ValidationResult(
                    "You must select at least one option", 
                    new[] { "SelectedOption" }
                );
            }
        }
    }
