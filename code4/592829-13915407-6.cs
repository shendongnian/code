    public IEnumerable<TimeItem> GetOverlappingItems(this IList<TimeItem> source)
    {
        // Validate parameters.
        if (source == null) throw new ArgumentNullException("source");
    
        // The indexes to ignore that have been yielded.
        var yielded = new HashSet<int>();
    
        // Iterate using indexer.
        for (int index = 0; index < source.Count; ++index)
        {
            // If the index is in the hash set then skip.
            if (yielded.Contains(index)) continue;
    
            // Did the look ahead yield anything?
            bool lookAheadYielded = false;
    
            // The item.
            TimeItem item = source[index];
    
            // Cycle through the rest of the indexes which are
            // not in the hashset.
            for (int lookAhead = index + 1; lookAhead < source.Count; ++lookAhead)
            {
                // If the item has been yielded, skip.
                if (yielded.Contains(lookAhead)) continue;
    
                // Get the other time item.
                TimeItem other = source[lookAhead];
    
                // Compare the two.  See if the start or the end
                // is between the look ahead.
                if (Utilities.IsBetween(item.SpanRangeStartIndex,
                        other.SpanRangeStartIndex, other.SpanRangeEndIndex) ||
                    Utilities.IsBetween(item.SpanRangeEndIndex,
                        other.SpanRangeStartIndex, other.SpanRangeEndIndex))
                {
                    // This is going to be yielded.
                    lookAheadYielded = true;
    
                    // Yield the item.
                    yield return other;
    
                    // Add the index to the hashset of what was yielded.
                    yielded.Add(lookAhead);
                }
            }
    
            // Was a look ahead yielded?
            // No need to store the index, we're only moving
            // forward and this index doesn't matter anymore.
            if (lookAheadYielded) yield return item;
        }
    }
