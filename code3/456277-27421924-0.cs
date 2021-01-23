    public class BaseErrWarn : Attribute
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public BaseErrWarn(string code, string description)
        {
            this.Code = code;
            this.Description = description;
        }
    }
    public enum ErrorCode
    {
        [BaseErrWarn("ClientErrMissingOrEmptyField", "Field was missing or empty.")] ClientErrMissingOrEmptyField,
        [BaseErrWarn("ClientErrInvalidFieldValue", "Not a valid field value.")] ClientErrInvalidFieldValue,
        [BaseErrWarn("ClientErrMissingValue", "No value passed in.")] ClientErrMissingValue
    }
    
