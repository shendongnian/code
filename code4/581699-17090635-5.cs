            DataTable dtblToUpdate = new DataTable();
            dtblToUpdate.Columns.AddRange(new DataColumn[]{new DataColumn("ColToJoinOn1"), new DataColumn("ColToJoinOn2"), new DataColumn("ColToUpdate")});
            dtblToUpdate.Rows.Add("1", "1", "nothing");
            dtblToUpdate.Rows.Add("2", "1", "nothing");
            dtblToUpdate.Rows.Add("3", "1", "nothing");
            
            DataTable dtblToUpdateFrom = new DataTable();
            dtblToUpdateFrom.Columns.AddRange(new DataColumn[]{new DataColumn("ColToJoinOn1"), new DataColumn("ColToJoinOn2"), new DataColumn("ColToUpdateFrom")});
            dtblToUpdateFrom.Rows.Add("1", "1", "something");
            dtblToUpdateFrom.Rows.Add("2", "1", "something");
            dtblToUpdateFrom.Rows.Add("3", "2", "something"); //Won't be updated since ColToJoinOn2 does not match in dtlbToUpdate
             
            Console.WriteLine("dtblToUpdate before update:");
            foreach(DataRow drow in dtblToUpdate.Rows)
            {
                Console.WriteLine(drow["ColToJoinOn1"].ToString() + "." + drow["ColToJoinOn2"].ToString() + " - " + drow["ColToUpdate"].ToString());
            }
            
            dtblToUpdate.Rows.Cast<DataRow>().Join(dtblToUpdateFrom.Rows.Cast<DataRow>(),
            r1 => new { p1 = r1["ColToJoinOn1"], p2 = r1["ColToJoinOn2"] },
            r2 => new { p1 = r2["ColToJoinOn1"], p2 = r2["ColToJoinOn2"] },
            (r1, r2) => new { r1, r2 }).ToList()
            .ForEach(o => o.r1.SetField("ColToUpdate", o.r2["ColToUpdateFrom"]));
            
            Console.WriteLine("dtblToUpdate after update:");
            foreach(DataRow drow in dtblToUpdate.Rows)
            {
                Console.WriteLine(drow["ColToJoinOn1"].ToString() + "." + drow["ColToJoinOn2"].ToString() + " - " + drow["ColToUpdate"].ToString());
            }
