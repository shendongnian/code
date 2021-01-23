    var completeObjects = byteList
        // This is required to access the index, and use integer
        // division (to ignore any reminders) to group them into
        // sets by three bytes in each.
        .Select((value, idx) => new { group = idx / 3, value })
        .GroupBy(x => x.group, x => x.value)
        // This is just to be able to access them using indices.
        .Select(x => x.ToArray())
        // This is a superfluous comment.
        .Select(x => new {
            Address = x[0],
            OldValue = x[1],
            NewValue = x[2]
        })
        .ToList();
