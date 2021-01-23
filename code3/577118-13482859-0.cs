    var result = from v in vendor
                 from l in location
                 where l.Mnemonic == v.StMnemon
                 group v by new { l.State, v.Rating } into grp
                 orderby grp.Key.Rating ascending, grp.Key.State
                 select new {State = grp.Key.State, Rating = grp.Key.Rating, Kinds = grp.Sum(p=>p.Items)};
    foreach (var item in result)
            Console.WriteLine("{0}\t{1}\t{2}", item.State, item.Rating, item.Kinds);
