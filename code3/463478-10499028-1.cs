    using (var iterator = dictionary.GetEnumerator())
    {
        while (iterator.MoveNext())
        {
            var entry = iterator.Current;
            string key = entry.Key;
            int value = entry.Value;
            // Use them...
        }
    }
