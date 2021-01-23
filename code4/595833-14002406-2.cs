    list.Select((item, index) => new {
        Index=index, 
        Length=Enumerable.Range(1, item.Length)
                         .Reverse()
                         .First(proposedLength => list.Count(innerItem => innerItem.StartsWith(item.Substring(0, proposedLength))) > 1)
    }).Select(n => list[n.Index].Substring(0, n.Length))
      .Distinct()
