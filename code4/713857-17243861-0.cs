    public IEnumerable<ValidationResult> Validate(ValidationContext context) {
        if (!States.contains(this.State)){
            yield return new ValidationResult("Invalid state.", new[] { "State" });
        }
    }
