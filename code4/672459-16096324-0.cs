            //
            // Summary:
            //     Produces the set union of two sequences by using the default equality comparer.
            //
            // Parameters:
            //   first:
            //     An System.Collections.Generic.IEnumerable<T> whose distinct elements form
            //     the first set for the union.
            //
            //   second:
            //     An System.Collections.Generic.IEnumerable<T> whose distinct elements form
            //     the second set for the union.
            //
            // Type parameters:
            //   TSource:
            //     The type of the elements of the input sequences.
            //
            // Returns:
            //     An System.Collections.Generic.IEnumerable<T> that contains the elements from
            //     both input sequences, excluding duplicates.
            //
            // Exceptions:
            //   System.ArgumentNullException:
            //     first or second is null.
    public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);
