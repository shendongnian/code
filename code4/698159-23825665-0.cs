    // Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
    // Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
    
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using JetBrains.Annotations;
    
    namespace Microsoft.Data.Entity.Utilities
    {
        [DebuggerStepThrough]
        internal static class Check
        {
            [ContractAnnotation("value:null => halt")]
            public static T NotNull<T>([NoEnumeration] T value, [InvokerParameterName] [NotNull] string parameterName)
            {
                NotEmpty(parameterName, "parameterName");
    
                if (ReferenceEquals(value, null))
                {
                    throw new ArgumentNullException(parameterName);
                }
    
                return value;
            }
    ...
