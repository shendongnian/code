    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FileExtensionsAttribute : ValidationAttribute, IClientValidatable
    {
        private List<string> ValidExtensions { get; set; }
        public int MaxContentLength { get; set; }
        public FileExtensionsAttribute(string fileExtensions)
        {
            ValidExtensions = fileExtensions.Split('|').ToList();
        }
        public override bool IsValid(object value)
        {
            HttpPostedFileBase file = value as HttpPostedFileBase;
            if (file != null)
            {
                var fileName = file.FileName;
                var isValidExtension = ValidExtensions.Any(y => fileName.EndsWith(y));
                var isValidContentLength = file.ContentLength < MaxContentLength;
                return isValidExtension && isValidContentLength;
            }
            return true;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ValidationType = "file";
            rule.ErrorMessage = this.FormatErrorMessage(ErrorMessage);
            rule.ValidationParameters["fileextensions"] = string.Join(",", ValidExtensions);
            rule.ValidationParameters["maxcontentlength"] = MaxContentLength.ToString();
            yield return rule;
        }
    }
