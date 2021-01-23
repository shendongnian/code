    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (Name == "Adam")
                {
                    yield return
                        new ValidationResult("Nie podales imienia", new[] { "Name" });
                }
            }
