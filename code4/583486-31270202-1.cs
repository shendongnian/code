        IEnumerable<int> QuickSort(IEnumerable<int> list)
        {
            if (!list.Any())
                return list;
            var p = list.Average();
            return QuickSort(list.Where(x => x < p)).Concat(list.Where(x => x == p).Concat(QuickSort(list.Where(x => x > p))));
        }
