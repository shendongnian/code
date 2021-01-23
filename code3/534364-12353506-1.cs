public class WhateverYourObjectNameCreateViewModel : IValidatableObject
{
       #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Country=="USA" && string.IsNullOrEmpty(this.County))
            {
                yield return new ValidationResult("County is required");
            }
        }
        #endregion
}
