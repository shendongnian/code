#region Usings
using System.ComponentModel;
using System.Linq;
using FluentValidation.Results;
using Core.Validation.Helpers;
#endregion Usings
namespace Core.Domain.Base {
    public abstract class ValidatableDomainObject : DomainObject, IDataErrorInfo {
        public abstract ValidationResult SelfValidate();
        public bool IsValid {
            get { return SelfValidate().IsValid; }
        }
        public string Error {
            get { return ValidationHelper.GetError(SelfValidate()); }
        }
        public string this[string columnName] {
            get {
                var validationResults = SelfValidate();
                if (validationResults == null) return string.Empty;
                var columnResults = validationResults.Errors.FirstOrDefault(x => string.Compare(x.PropertyName, columnName, true) == 0);
                return columnResults != null ? columnResults.ErrorMessage : string.Empty;
            }
        }
    }
}
