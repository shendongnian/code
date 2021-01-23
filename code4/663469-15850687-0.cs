        var total = (from r in dt.AsEnumerable()
                     where r.Field<Int64>("subject_id") == 1
                     select new { Question = r.Field<string>("Question"), Marks = r.Field<Int64>("marks") }).ToList().Distinct();
        string strC = "";
        foreach (var item in total)
        {
            strC = strC + "<br/>" + "Question: " + item.Question + " Marks: " + item.Marks;
        }
        Response.Write(strC);
