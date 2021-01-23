    if (PropertyGetters.ContainsKey(columnName))
                {
                    ValidationContext context = new ValidationContext(this, null, null)
                    {
                        MemberName = columnName
                    };
                    List<ValidationResult> results = new List<ValidationResult>();
                    var value = GetType().GetProperty(columnName).GetValue(this, null);
                    return !Validator.TryValidateProperty(value, context, results)
                               ? string.Join(Environment.NewLine, results.Select(x => x.ErrorMessage))
                               : null;
                }
                return null;
