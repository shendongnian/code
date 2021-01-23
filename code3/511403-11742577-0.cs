    private void WriteData() {
        using (var file = System.IO.StreamWriter(@"C:\Path\To\File.csv")) {
            foreach (var row in dataGrid.Rows) {
                 foreach (var cell in row.Cells) {
                     file.Write(cell.Value).Write(",");
                 }
            }
            file.Write("\n");
        }
    }
