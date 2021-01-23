    Workbook workbook = new Workbook(new FileStream("book1.xls", FileMode.Open));
    if (workbook.Worksheets[0].ListObjects.Count > 0)
    {
         foreach (ListObject table in workbook.Worksheets[0].ListObjects)
         {
              Style st = new Style();
              st.BackgroundColor = System.Drawing.Color.Aqua;
              st.ForegroundColor = System.Drawing.Color.Black;
              st.Font.Name = "Agency FB";
              st.Font.Size = 16;
              st.Font.Color = System.Drawing.Color.DarkRed;
              StyleFlag stFlag = new StyleFlag();
              stFlag.All = true;
              table.DataRange.ApplyStyle(st, stFlag);
         }
    }
    workbook.Save("output.xls");
