    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            List<string> MyList = new List<string> { "second", "first", "second2", "wherever", "third", "second2", "third", "second", "first" };
    
            RuleBasedComparer<string> RuleComparer = new RuleBasedComparer<string>();
    
            // I want to ensure all instances of "first" appear in the list before all instances of "second" and "second2"
            // and all instances of "second" and "second2" appear in the list before all instances of "third".
            // I don't care where "wherever" appears (or anything beyond the above rules)
    
            RuleComparer.AddRule("first", "second");
            RuleComparer.AddRule("first", "second2");
            RuleComparer.AddRule("second", "third");
            RuleComparer.AddRule("second2", "third");
    
            MyList.Sort(RuleComparer);
    
            foreach (var item in MyList)
                Console.WriteLine(item);
            Console.ReadKey();
        }
    }
    
    public class RuleBasedComparer<T> : Comparer<T>
    {
        private class OrderRule
        {
            public readonly T Before;
            public readonly T After;
    
            public OrderRule(T before, T after)
            {
                Before = before;
                After = after;
            }
        }
    
        private List<OrderRule> _Rules = new List<OrderRule>();
    
        private List<T> DesiredOrdering = new List<T>();
    
        private bool _NeedToCalculateOrdering = true;
    
        public void AddRule(T before, T after)
        {
            if (!_NeedToCalculateOrdering)
                throw new InvalidOperationException("Cannot add rules once this comparer has.");
    
            _Rules.Add(new OrderRule(before, after));
        }
    
        private void CalculateOrdering()
        {
            _NeedToCalculateOrdering = false;
    
            var ItemsToOrder = _Rules.SelectMany(r => new[] { r.Before, r.After }).Distinct();
    
    
            foreach (var ItemToOrder in ItemsToOrder)
            {
                var MinIndex = 0;
                var MaxIndex = DesiredOrdering.Count;
    
                foreach (var Rule in _Rules.Where(r => r.Before.Equals(ItemToOrder)))
                {
                    var indexofAfter = DesiredOrdering.IndexOf(Rule.After);
    
                    if (indexofAfter != -1)
                    {
                        MaxIndex = Math.Min(MaxIndex, indexofAfter);
                    }
                }
    
                foreach (var Rule in _Rules.Where(r => r.After.Equals(ItemToOrder)))
                {
                    var indexofBefore = DesiredOrdering.IndexOf(Rule.Before);
    
                    if (indexofBefore != -1)
                    {
                        MinIndex = Math.Max(MinIndex, indexofBefore + 1);
                    }
                }
    
                if (MinIndex > MaxIndex)
                    throw new InvalidOperationException("Invalid combination of rules found!");
    
                DesiredOrdering.Insert(MinIndex, ItemToOrder);
            }
        }
    
        public override int Compare(T x, T y)
        {
            if (_NeedToCalculateOrdering)
                CalculateOrdering();
    
            if (x == null && y != null)
            {
                return -1;
            }
            else if (x != null && y == null)
                return 1;
            else if (x == null && y == null)
                return 0;
    
            // Find the applicable rule for this pair (if any)
            var IndexOfX = DesiredOrdering.IndexOf(x);
            var IndexOfY = DesiredOrdering.IndexOf(y);
    
            if (IndexOfX != -1 && IndexOfY != -1)
            {
                // We have a definite order
                if (IndexOfX > IndexOfY)
                    return 1;
                else if (IndexOfX < IndexOfY)
                    return -1;
                else
                    return 0;
            }
            else if (IndexOfX != -1)
            {
                return -1;
            }
            else if (IndexOfY != -1)
            {
                return 1;
            }
            else
            {
                return 0; // Or maybe compare x to y directly
                //return Comparer<T>.Default.Compare(x, y);
            }
        }
    }
