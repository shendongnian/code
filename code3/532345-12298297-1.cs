    var withRev = list.Where(s => s.IndexOf("rev.", StringComparison.OrdinalIgnoreCase) > -1);
    var withoutRev = list.Except(withRev);
 
    var orderedWithRev = withRev
        .Select(r => new { 
            Item = r, 
            RevIndex = r.LastIndexOf("rev.", StringComparison.OrdinalIgnoreCase)
        })
        .Select(x => new{
            x.Item,
            RevisionItem = x.Item.Substring(0, x.RevIndex),
            Revision = int.Parse(x.Item.Substring(x.RevIndex + 4))
        })
        .GroupBy(x => x.RevisionItem.ToLower())
        .Select(g => g.OrderByDescending(x => x.Revision).First().Item);
    foreach (var wr in withoutRev)
        listBox1.Items.Add(wr);
    foreach (var r in orderedWithRev)
        listBox1.Items.Add(r);
