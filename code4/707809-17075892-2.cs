     // For each place where the word s appears in original...
    .SelectMany((s, i) => lookup[s]
      // Define the two subsequences of userSelect and original to work on.
      // We are trying to find the number of identical elements until first mismatch.
      .Select(j => new { User = userSelect.Skip(i), Original = original.Skip(j), Skipped = j })
      // Use .Zip to find this subsequence
      .Select(t => t.User.Zip(t.Original, (u, v) => Tuple.Create(u, v, t.Skipped)).TakeWhile(tuple => tuple.Item1 == tuple.Item2))
      // Note the index in original where the subsequence started and its length
      // Word is not actually necessary, I used it for sanity when coding along
      .Select(u => new { Word = s, Start = u.Select(v => v.Item3).Min(), Length = u.Count() })
    )
