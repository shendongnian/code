      using System;
      using System.Diagnostics;
      using System.Diagnostics.CodeAnalysis;
      using System.Diagnostics.Contracts;
    
      /// <summary>Extension methods to enhance Code Contracts and integration with Code Analysis.</summary>
      public static class ContractExtensions {
    #if RUNTIME_NULL_CHECKS
        /// <summary>Throws <c>ArgumentNullException{name}</c> if <c>value</c> is null.</summary>
        /// <param name="value">Value to be tested.</param>
        /// <param name="name">Name of the parameter being tested, for use in the exception thrown.</param>
        [ContractArgumentValidator]  // Requires Assemble Mode = Custom Parameter Validation
        public static void ContractedNotNull<T>([ValidatedNotNull]this T value, string name) where T : class {
          if (value == null) throw new ArgumentNullException(name);
          Contract.EndContractBlock();
        }
    #else
        /// <summary>Throws <c>ContractException{name}</c> if <c>value</c> is null.</summary>
        /// <param name="value">Value to be tested.</param>
        /// <param name="name">Name of the parameter being tested, for use in the exception thrown.</param>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "value")]
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "name")]
        [ContractAbbreviator] // Requires Assemble Mode = Standard Contract Requires
        public static void ContractedNotNull<T>([ValidatedNotNull]this T value, string name) where T : class {
          Contract.Requires(value != null,name);
        }
    #endif
      }
    /// <summary>Decorator for an incoming parameter that is contractually enforced as NotNull.</summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class ValidatedNotNullAttribute : global::System.Attribute {}
