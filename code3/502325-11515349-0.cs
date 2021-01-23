    class BaseResponse
        {
            public bool HasErrors
            {
                get;
                set;
            }
    
            public Collection<String> Errors
            {
                get;
                set;
            }
        }
