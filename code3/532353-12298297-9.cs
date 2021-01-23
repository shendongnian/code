    var withRev = list.Where(s => s.IndexOf("rev.", StringComparison.OrdinalIgnoreCase) > -1);
    var withoutRev = list.Except(withRev);
    var orderedWithRev = withRev
        .Select(r => { 
            int RevIndex = r.LastIndexOf("rev.", StringComparison.OrdinalIgnoreCase);
            String[] tokens = r
                .Substring(RevIndex + "rev.".Length)
                .Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            return new
            {
                Item = r,
                RevIndex,
                RevisionItem = r.Substring(0, RevIndex),
                MainRevision = int.Parse(tokens[0]),
                SubRevision  = tokens.Length > 1 ? int.Parse(tokens[1]) : 0
            };
        })
        .GroupBy(x => x.RevisionItem.ToLower())
        .Select(g => g
            .OrderByDescending(x => x.MainRevision)
            .ThenByDescending( x => x.SubRevision)
            .First().Item);
    foreach (var wr in withoutRev)
        listBox1.Items.Add(wr);
    foreach (var r in orderedWithRev)
        listBox1.Items.Add(r);
