    using System;
    using System.Collections.Generic;
    static class MyExtensions
    {
        public static IEnumerable<TResult> AggregatingSelect<TItem, TAggregate, TResult>(
            this IEnumerable<TItem> items,
            Func<TItem, TAggregate, TAggregate> aggregator,
            TAggregate initial,
            Func<TItem, TAggregate, TResult> projection)
        {
            TAggregate aggregate = initial;
            foreach (TItem item in items)
            {
                aggregate = aggregator(item, aggregate);
                yield return projection(item, aggregate);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 3, 1, 4, 9 };
            var result = numbers.AggregatingSelect(
                (int item, int agg) => item + agg, 
                0, 
                (int item, int agg) => agg);
            Console.WriteLine(string.Join(",", result));
        }
    }
