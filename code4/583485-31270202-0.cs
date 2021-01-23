        static IEnumerable<int> QuickSort(IEnumerable<int> input)
        {
            if (input.ToList().Count == 0)
                return input;
            var pivot = (double)((input.First() + input.Last())/2);
            var left = QuickSort(input.Where(n => n < pivot));
            var mid = input.Where(n => n == pivot);
            var right = QuickSort(input.Where(n => n > pivot));
            return left.Concat(mid).Concat(right);
        }
