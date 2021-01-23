    var withRev = list.Where(s => s.IndexOf("rev.", StringComparison.OrdinalIgnoreCase) > -1);
    var withoutRev = list.Except(withRev);
    var orderedWithRev = withRev
    .Select(r => { 
        int RevIndex = r.LastIndexOf("rev.", StringComparison.OrdinalIgnoreCase);
        return new
        {
            Item = r,
            RevIndex,
            RevisionItem = r.Substring(0, RevIndex),
            Revision = int.Parse(r.Substring(RevIndex + "rev.".Length))
        };
    })
    .GroupBy(x => x.RevisionItem.ToLower())
    .Select(g => g.OrderByDescending(x => x.Revision).First().Item);
    foreach (var wr in withoutRev)
        listBox1.Items.Add(wr);
    foreach (var r in orderedWithRev)
        listBox1.Items.Add(r);
