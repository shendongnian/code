            Application app = new Application();
            Workbook wb = app.Workbooks.Open("C:\\Data\\ABC.xlsx",
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);
            Worksheet ws = wb.Sheets[1];
            Range rng = ws.Range["A1:C5", Type.Missing];
            object cols = new object[]{1, 2};
            rng.RemoveDuplicates(cols, XlYesNoGuess.xlYes);
