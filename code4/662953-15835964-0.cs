    public abstract class BaseModel : IDataErrorInfo {
        protected Type _type;
        protected readonly Dictionary<string, ValidationAttribute[]> _validators;
        protected readonly Dictionary<string, PropertyInfo> _properties;
        public BaseModel() {
            _type = this.GetType();
            _properties = _type.GetProperties().ToDictionary(p => p.Name, p => p);
            _validators = _properties.Where(p => _getValidations(p.Value).Length != 0).ToDictionary(p => p.Value.Name, p => _getValidations(p.Value));
        }
        protected ValidationAttribute[] _getValidations(PropertyInfo property) {
            return (ValidationAttribute[])property.GetCustomAttributes(typeof(ValidationAttribute), true);
        }
        public string this[string columnName] {
            get {
                if (_properties.ContainsKey(columnName)) {
                    var value = _properties[columnName].GetValue(this, null);
                    var errors = _validators[columnName].Where(v => !v.IsValid(value)).Select(v => v.ErrorMessage).ToArray();
                    return string.Join(Environment.NewLine, errors);
                }
                return string.Empty;
            }
        }
        public string Error {
            get { throw new NotImplementedException(); }
        }
    }
