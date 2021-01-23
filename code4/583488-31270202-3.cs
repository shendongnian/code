        IEnumerable<int> QuickSort(IEnumerable<int> i)
        {
            if (!i.Any())
                return i;
            var p = (i.First() + i.Last) / 2 //whichever pivot method you choose
            return QuickSort(i.Where(x => x < p)).Concat(i.Where(x => x == p).Concat(QuickSort(i.Where(x => x > p))));
        }
