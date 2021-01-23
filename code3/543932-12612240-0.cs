            var dtC = new DataTable("CombinationOfBoth");
            dtC.Columns.Add("Firstname",typeof(string));
            dtC.Columns.Add("Lastname", typeof (string));
            dtC.Columns.Add("Grade1", typeof (int));
            dtC.Columns.Add("Grade2", typeof(int));
            dtC.Columns.Add("Grade3", typeof(int));
            dtC.Merge(dtA,false,MissingSchemaAction.Ignore);
            dtC.Merge(dtB, false, MissingSchemaAction.Ignore);
