    using (IEnumerator<T> e = source.GetEnumerator()) {
        IList<T> saved = new List<T>(greaterIndex-smallerIndex+1);
        int index = 0;
        while (e.MoveNext()) {
            // If we're outside the swapped indexes, yield return the current element
            if (index < smallerIndex || index > greaterIndex) {
                index++;
                yield return e.Current;
            } else if (index == smallerIndex) {
                var atSmaller = e.Current;
                // Save all elements starting with the current one into a list;
                // Continue until you find the last index, or exhaust the sequence.
                while (index != greaterIndex && e.MoveNext()) {
                    saved.Add(e.Current);
                    index++;
                }
                // Make sure we're here because we got to the greaterIndex,
                // not because we've exhausted the sequence
                if (index == greaterIndex) {
                    // If we are OK, return the element at greaterIndex
                    yield return e.Current;
                }
                // Enumerate the saved items
                for (int i = 0 ; i < saved.Count-1 ; i++) {
                    yield return saved[i];
                }
                // Finally, return the item at the smallerIndex
                yield return atSmaller;
                index++;
            }
        }
    }
