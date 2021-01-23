        public BaseError(Enum errorCode)
        {
            BaseErrWarn baseError = GetAttribute(errorCode);
            this.Code = baseError.Code;
            this.Description = baseError.Description;
        }
        public BaseError(Enum errorCode, string fieldName)
        {
            BaseErrWarn baseError = GetAttribute(errorCode);
            this.Code = baseError.Code;
            this.Description = baseError.Description;
            this.FieldName = fieldName;
        }  
