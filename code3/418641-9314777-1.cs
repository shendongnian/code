    var doc = XDocument.Load(in_A);
    var doc2 = XDocument.Load(in_B);
    var descendats = doc.Descendants().Select(d => 
        d.AncestorsAndSelf().Reverse().Select(el => 
            new {idx = el.ElementsBeforeSelf(el.Name).Count(), el, name = el.Name}).ToList());
    
    foreach (var list in descendats.OrderByDescending(l => l.Count)) {
        XContainer el = doc2;
        var el2 = list.Last().el;
        foreach (var item in list) {
            if (el == null) break;
            el = el.Elements(item.name).Skip(item.idx).FirstOrDefault();
        }
        string changed = "";
        if (el == null) changed += " deleted";
        else {
            var el1 = el as XElement;
            if (el1.Attributes().Select(a => new { a.Name, a.Value })
                .Except(el2.Attributes().Select(a => new { a.Name, a.Value })).Count() > 0) {
                    changed += " attributes";
            }
            if (!el1.HasElements && el1.Value != el2.Value) {
                changed += " value";
            }
            el1.Remove();
        }
        if (changed != "") el2.SetAttributeValue("changed", changed.Trim());
    }
    doc.Save(out_A);
