    var SearchColumn = from qua in Qual
                   join del in deliverables on qua.Q_ID equals del.Q_ID into left_j
                                from del in left_j.DefaultIfEmpty()
                                select new { qua.Name + " " + qua.Project + " " + qua.Summary + " " + del.Name + " " + del.Summary).ToLower() };
    foreach (var f in searchFilter)
    {
       var likestr = string.Format("%{0}%", f);
       SearchColumn = SearchColumn.Where(x => SqlMethods.Like(x.Search_Col, likestr));
    }
