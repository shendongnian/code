    var doc = XDocument.Load(in_A);
    var doc2 = XDocument.Load(in_B);
    var descendants = doc.Descendants().Select(d => 
        d.AncestorsAndSelf().Reverse().Select(el => 
            new {idx = el.ElementsBeforeSelf(el.Name).Count(), el, name = el.Name}).ToList());
    
    foreach (var list in descendants) {
        XContainer el2 = doc2;
        var el = list.Last().el;
        foreach (var item in list) {
            if (el2 == null) break;
            el2 = el2.Elements(item.name).Skip(item.idx).FirstOrDefault();
        }
        string changed = "";
        if (el2 == null) changed += " deleted";
        else {
            var el2e = el2 as XElement;
            if (el2e.Attributes().Select(a => new { a.Name, a.Value })
                .Except(el.Attributes().Select(a => new { a.Name, a.Value })).Count() > 0) {
                    changed += " attributes";
            }
            if (!el2e.HasElements && el2e.Value != el.Value) {
                changed += " value";
            }
            el2e.SetAttributeValue("found", "found");
        }
        if (changed != "") el.SetAttributeValue("changed", changed.Trim());
    }
    doc.Save(out_A);
    doc2.Save(out_B);
