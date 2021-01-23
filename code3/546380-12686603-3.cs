#region Usings
using System;
using System.Text;
using FluentValidation;
using FluentValidation.Results;
#endregion Usings
namespace Core.Validation.Helpers {
    public class ValidationHelper {
        public static ValidationResult Validate<T, TK>(TK entity)
            where T : IValidator<TK>, new()
            where TK : class {
            IValidator<TK> validator = new T();
            return validator.Validate(entity);
        }
        public static string GetError(ValidationResult result) {
            var validationErrors = new StringBuilder();
            foreach (var validationFailure in result.Errors) {
                validationErrors.Append(validationFailure.ErrorMessage);
                validationErrors.Append(Environment.NewLine);
            }
            return validationErrors.ToString();
        }
    }
}
