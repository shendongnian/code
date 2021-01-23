    private void WriteData() {
        using (var file = System.IO.StreamWriter(@"C:\Path\To\File.csv")) {
            foreach (var row in dataGrid.Rows) {
                 foreach (var cell in row.Cells) {
                     // Note that if some cells contain commas, 
                     // you'd need to wrap them in quotes.
                     file.Write(cell.Value).Write(",");
                 }
            }
            file.Write("\n");
        }
    }
