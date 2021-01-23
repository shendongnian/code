       private void processsub()
        {
            List<String[]> lista = new List<string[]>();
            lista.Add(new string[] { "text1", "text2", "text3", "text4", "text5", "text6", "text7" });
            dataGridView1.AutoGenerateColumns = true;
            DataTable table = ConvertListtoDatTable(lista);
            dataGridView1.DataSource = table;
        }
        private DataTable ConvertListtoDatTable(List<String[]> lista)
        {
            DataTable table = new DataTable();
            int columnCount = lista[0].Length;
            for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
            {
                table.Columns.Add();
            }
            foreach (string[] row in lista)
            {
                table.Rows.Add(row);
            }
            return table;
        }
        private void buttonTest_Click(object sender, EventArgs e)
        {
            processsub();
        }
