    using System;
    namespace Common.FluentValidation
    {
        public static partial class Validate
        {
            /// <summary>
            /// Validates the passed in parameter is within a specified range of values, throwing a detailed exception message if the test fails.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="p_parameter">Parameter to validate.</param>
            /// <param name="p_minInclusive">The minimum valid value of the parameter.</param>
            /// <param name="p_maxInclusive">The maximum valid value of the parameter.</param>
            /// <param name="p_name">Name of tested parameter to assist with debugging.</param>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            public static void MustBeWithinRange<T>(this IComparable<T> p_parameter, T p_minInclusive, T p_maxInclusive, string p_name)
                where T : struct
            {
                if (p_parameter.CompareTo(p_minInclusive) == -1)
                    throw
                        new
                            ArgumentOutOfRangeException(string.Format(
                            "Parameter cannot be less than {0}, but \"{1}\" was {2}.",
                            p_minInclusive, p_name, p_parameter), default(Exception));
                if (p_parameter.CompareTo(p_maxInclusive) == 1)
                    throw
                        new
                            ArgumentOutOfRangeException(string.Format(
                            "Parameter cannot be greater than {0}, but \"{1}\" was {2}.",
                            p_maxInclusive, p_name, p_parameter), default(Exception));
            }
        }
    }
