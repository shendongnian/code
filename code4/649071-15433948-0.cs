     for (int i = 0; i < gv.Columns.Count; i++)
     {
          DataControlFieldCell cell = gv.Rows[e.RowIndex].Cells[i] as DataControlFieldCell;
          gv.Columns[i].ExtractValuesFromCell(e.NewValues, cell, DataControlRowState.Edit, true);
     }
