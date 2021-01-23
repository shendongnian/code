        using Microsoft.Office.Interop.Word;
        ......
        void AddTable()
        {
          Range rng = Globals.ThisAddIn.Application.Selection.Range;
          Table tbl = rng.Tables.Add(rng, 3, 5); //make table at current selection
          tbl.Range.Font.Name = "Calibri";
		  tbl.Range.Font.Size = 10.5F;
		  tbl.Range.Font.Bold = 0;
          //these 2 lines put borders both inside & outside - see result image at end
          tbl.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
    	  tbl.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
          for (r = 1; r <= 3; r++)
            for (c = 1; c <= 5; c++)
            {
              strText = "r" + r + "c" + c;
              oTable.Cell(r, c).Range.Text = strText;
            }
        }
