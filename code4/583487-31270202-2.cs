        IEnumerable<int> QuickSort(IEnumerable<int> i)
        {
            if (!i.Any())
                return i;
            var p = new Random().Next(i.First(), i.Last());
            return QuickSort(i.Where(x => x < p)).Concat(i.Where(x => x == p).Concat(QuickSort(i.Where(x => x > p))));
        }
