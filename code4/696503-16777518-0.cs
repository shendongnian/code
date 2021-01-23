    var mostFrequentlyUsedEntriesOfList = inputList
        .GroupBy(word => word)
        .Select(wordGroup => new
        {
            Word = wordGroup.Key,
            Frequency = wordGroup.Count(),
            Position = Enumerable.Range(0, inputList.Count())
                .OrderByDescending(index => inputList.Skip(index).TakeWhile(current => current == wordGroup.Key).Count())
                .First() + 1
        })
        .OrderByDescending(word => word.Frequency);
