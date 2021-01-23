                this.tblSubsets = new DataTable();
                this.tblSubsets.Columns.AddRange(new DataColumn[] {
                    new DataColumn()
                    {
                        AllowDBNull = false
                        , ColumnName = "Member"
                        , DataType = typeof(Func<Member>)
                    }
                });
                var members = new Dictionary<int, Member>();
                this.tblSubsets.RowChanged += new DataRowChangeEventHandler((object sender, DataRowChangeEventArgs e) =>
                {
                    if (e.Action != DataRowAction.Add)
                    {
                        return;
                    }
                    e.Row["Member"] = new Func<Member>(() =>
                    {
                        Member returnValue;
                        var mid = Convert.ToInt32(e.Row["MemberID"]);
                        if (!members.TryGetValue(mid, out returnValue))
                        {
                            members.Add(mid, (returnValue = new Member(mid)));
                        }
                        return returnValue;
                    });
                });
                var com = new SqlConnection(functions.ConnectionString).CreateCommand();
                com.CommandText = @"
    SELECT
        S.id
        , S.Name
        , S.MemberID
    FROM dbo.SubSets AS S
    WHERE S.SubsetType = 0
    ";
                new SqlDataAdapter(com).Fill(this.tblSubsets);
