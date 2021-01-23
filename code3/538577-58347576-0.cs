            internal static class Check
        {
            [ContractAnnotation("value:null => halt")]
            public static T NotNull<T>([NoEnumeration] T value, [InvokerParameterName] [NotNull] string parameterName)
            {
    #pragma warning disable IDE0041 // Use 'is null' check
                if (ReferenceEquals(value, null))
    #pragma warning restore IDE0041 // Use 'is null' check
                {
                    NotEmpty(parameterName, nameof(parameterName));
    
                    throw new ArgumentNullException(parameterName);
                }
    
                return value;
            }
