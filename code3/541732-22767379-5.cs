    using System;
    using System.Collections.Generic;
    using Common.FluentValidation;
    namespace Common.Extensions
    {
        public static partial class ExtensionMethods
        {
            /// <summary>
            /// Gets the index for an array relative to an anchor point, seamlessly crossing array boundaries in either direction.
            /// Returns calculated index value of an element within a collection as if the collection was a ring of contiguous elements (Ring Buffer).
            /// </summary>
            /// <param name="p_rollover">Index value after which the iterator should return back to zero.</param>
            /// <param name="p_anchor">A fixed or variable position to offset the iteration from.</param>
            /// <param name="p_offset">A fixed or variable position to offset from the anchor.</param>
            /// <returns>calculated index value of an element within a collection as if the collection was a ring of contiguous elements (Ring Buffer).</returns>
            public static int Span(this int p_rollover, int p_anchor, int p_offset)
            {
                // Prevent absolute value of `n` from being larger than count
                int n = (p_anchor + p_offset) % p_rollover;
                // If `n` is negative, then result is n less than rollover
                if (n < 0)
                    n = n + p_rollover;
                return n;
            }
            /// <summary>
            /// Iterates over a collection from a specified start position to an inclusive end position. Iterator always increments
            /// from start to end, treating the original collection as a contiguous ring of items to be projected into a new form.
            /// Returns a projected collection of items that can contain all of the items from the original collection or a subset of the items.
            /// The first item in the projected collection will be the item from the original collection at index position p_first.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="p_collection">The collection to project into a new form.</param>
            /// <param name="p_first">Zero based index value of the first element in the projected sequence.</param>
            /// <param name="p_last">Zero based index value of the last element in the projected sequence.</param>
            /// <returns>a projected collection of items that can contain all of the items from the original collection or a subset of the items.
            /// The first item in the projected collection will be the item from the original collection at index position p_first.</returns>
            public static IEnumerable<T> SpanRange<T>(this IList<T> p_collection, int p_first, int p_last)
            {
                // Validate
                p_collection
                    .CannotBeNullOrEmpty("p_collection");
                p_first
                    .MustBeWithinRange(0, p_collection.Count - 1, "p_first");
                p_last
                    .MustBeWithinRange(0, p_collection.Count - 1, "p_last");
                // Init
                int Rollover = p_collection.Count;
                int Count = (p_first <= p_last) ? p_last - p_first : (Rollover - p_first) + p_last;
                // Iterate
                for (int i = 0; i <= Count; i++)
                {
                    var n = Rollover.Span(p_first, i);
                    yield return p_collection[n];
                }
            }
        }
    }
