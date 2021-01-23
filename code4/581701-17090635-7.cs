    dtblToUpdate.Rows.Cast<DataRow>().Join(dtblToUpdateFrom.Rows.Cast<DataRow>(),
                r1 => new { p1 = r1["ColToJoinOn1"], p2 = r1["ColToJoinOn2"] },
                r2 => new { p1 = r2["ColToJoinOn1"], p2 = r2["ColToJoinOn2"] },
                (r1, r2) => new { r1, r2 }).ToList()
                .ForEach(o => o.r1.SetField("ColToUpdate", o.r2["ColToUpdateFrom"]));
