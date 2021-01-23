    /// <summary>Provides a function delegate that accepts only value types as return types.</summary>
    /// <remarks>This type was introduced to make <see cref="ObjectExtensions.NullOr{TInput,TResult}(TInput,FuncStruct{TInput,TResult})"/>
    /// work without clashing with <see cref="ObjectExtensions.NullOr{TInput,TResult}(TInput,FuncClass{TInput,TResult})"/>.</remarks>
    public delegate TResult FuncStruct<in TInput, TResult>(TInput input) where TResult : struct;
    /// <summary>Provides a function delegate that accepts only reference types as return types.</summary>
    /// <remarks>This type was introduced to make <see cref="ObjectExtensions.NullOr{TInput,TResult}(TInput,FuncClass{TInput,TResult})"/>
    /// work without clashing with <see cref="ObjectExtensions.NullOr{TInput,TResult}(TInput,FuncStruct{TInput,TResult})"/>.</remarks>
    public delegate TResult FuncClass<in TInput, TResult>(TInput input) where TResult : class;
    /// <summary>Provides extension methods that apply to all types.</summary>
    public static class ObjectExtensions
    {
        /// <summary>Returns null if the input is null, otherwise the result of the specified lambda when applied to the input.</summary>
        /// <typeparam name="TInput">Type of the input value.</typeparam>
        /// <typeparam name="TResult">Type of the result from the lambda.</typeparam>
        /// <param name="input">Input value to check for null.</param>
        /// <param name="lambda">Function to apply the input value to if it is not null.</param>
        public static TResult NullOr<TInput, TResult>(this TInput input, FuncClass<TInput, TResult> lambda) where TResult : class
        {
            return input == null ? null : lambda(input);
        }
        /// <summary>Returns null if the input is null, otherwise the result of the specified lambda when applied to the input.</summary>
        /// <typeparam name="TInput">Type of the input value.</typeparam>
        /// <typeparam name="TResult">Type of the result from the lambda.</typeparam>
        /// <param name="input">Input value to check for null.</param>
        /// <param name="lambda">Function to apply the input value to if it is not null.</param>
        public static TResult? NullOr<TInput, TResult>(this TInput input, Func<TInput, TResult?> lambda) where TResult : struct
        {
            return input == null ? null : lambda(input);
        }
        /// <summary>Returns null if the input is null, otherwise the result of the specified lambda when applied to the input.</summary>
        /// <typeparam name="TInput">Type of the input value.</typeparam>
        /// <typeparam name="TResult">Type of the result from the lambda.</typeparam>
        /// <param name="input">Input value to check for null.</param>
        /// <param name="lambda">Function to apply the input value to if it is not null.</param>
        public static TResult? NullOr<TInput, TResult>(this TInput input, FuncStruct<TInput, TResult> lambda) where TResult : struct
        {
            return input == null ? null : lambda(input).Nullable();
        }
    }
