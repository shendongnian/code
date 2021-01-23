    public static IEnumerable<string> ValidateObject(this object model)
    {
        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();
        Validator.TryValidateObject(model, context, results);
        return results.Select(r => r.ErrorMessage);
    }
