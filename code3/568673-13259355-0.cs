    foreach (Row r in this.dataGridView1.Rows) {
        if (r.Cells[3].Value <= r.Cells[2].Value ) {
        System.Console.WriteLine ("error");
        }
    }
