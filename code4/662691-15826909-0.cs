        DataSet ds = new DataSet();
        DataTable dtPrimary = new DataTable();
        dtPrimary.Columns.Add("Id", typeof(int));
        dtPrimary.Columns.Add("Name", typeof(string));
        DataTable dtForeign = new DataTable();
        dtForeign.Columns.Add("Id", typeof(int));
        dtForeign.Columns.Add("Name",typeof(string));
        ds.Tables.Add(dtPrimary);
        ds.Tables.Add(dtForeign);
        DataRelation dr = new DataRelation("myRelation", dtPrimary.Columns["Id"], dtForeign.Columns["Id"]);
        dtPrimary.Rows.Add(1, "Name1");
        dtPrimary.Rows.Add(2, "Name2");
        dtForeign.Rows.Add(1,"Child1OfName1");
        dtForeign.Rows.Add(1, "Child2OfName1");
        dtForeign.Rows.Add(2, "ChildOfName2");
        DataTable dtNew = new DataTable();
        dtNew.Columns.Add("Id");
        dtNew.Columns.Add("Name");
    var items =
        from row in dtPrimary.AsEnumerable()
        let foreignRow = (
        from innerRow in dtForeign.AsEnumerable()
        where innerRow.Field<int>("Id") == row.Field<int>("Id")
        select innerRow)
        select new { Parent = row.Field<string>("Name"), Children = foreignRow };
