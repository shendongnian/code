    public class MaxFileSizeAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly int _maxFileSize;
        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }
        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file == null)
            {
                return false;
            }
            return file.ContentLength <= _maxFileSize;
        }
        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(_maxFileSize.ToString());
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(_maxFileSize.ToString()),
                ValidationType = "filesize"
            };
            rule.ValidationParameters["maxsize"] = _maxFileSize;
            yield return rule;
        }
    }
