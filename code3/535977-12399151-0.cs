        public T Value {
            get {
                if (!HasValue) { 
                    ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_NoValue);
                } 
                return value; 
            }
        } 
