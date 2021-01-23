    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Common.FluentValidation
    {
        public static partial class Validate
        {
            /// <summary>
            /// Validates the passed in parameter is not null or an empty collection, throwing a detailed exception message if the test fails.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="p_parameter">Parameter to validate.</param>
            /// <param name="p_name">Name of tested parameter to assist with debugging.</param>
            /// <exception cref="ArgumentNullException"></exception>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            public static void CannotBeNullOrEmpty<T>(this ICollection<T> p_parameter, string p_name)
            {
                if (p_parameter == null)
                    throw
                        new
                            ArgumentNullException(string.Format(
                            "The collection \"{0}\" cannot be null.",
                            p_name), default(Exception));
                if (p_parameter.Count <= 0)
                    throw
                        new
                            ArgumentOutOfRangeException(string.Format(
                            "The collection \"{0}\" cannot be empty.",
                            p_name), default(Exception));
            }
            /// <summary>
            /// Validates the passed in parameter is not null or an empty collection, throwing a detailed exception message if the test fails.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="p_parameter">Parameter to validate.</param>
            /// <param name="p_name">Name of tested parameter to assist with debugging.</param>
            /// <exception cref="ArgumentNullException"></exception>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            public static void CannotBeNullOrEmpty<T>(this IEnumerable<T> p_parameter, string p_name)
            {
                if (p_parameter == null)
                    throw
                        new
                            ArgumentNullException(string.Format(
                            "The collection \"{0}\" cannot be null.",
                            p_name), default(Exception));
                if (p_parameter.Count() <= 0)
                    throw
                        new
                            ArgumentOutOfRangeException(string.Format(
                            "The collection \"{0}\" cannot be empty.",
                            p_name), default(Exception));
            }
            /// <summary>
            /// Validates the passed in parameter is not null or empty, throwing a detailed exception message if the test fails.
            /// </summary>
            /// <param name="p_parameter">Parameter to validate.</param>
            /// <param name="p_name">Name of tested parameter to assist with debugging.</param>
            /// <exception cref="ArgumentException"></exception>
            public static void CannotBeNullOrEmpty(this string p_parameter, string p_name)
            {
                if (string.IsNullOrEmpty(p_parameter))
                    throw
                        new
                            ArgumentException(string.Format(
                            "The string \"{0}\" cannot be null or empty.",
                            p_name), default(Exception));
            }
        }
    }
