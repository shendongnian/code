            private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string path = dataGridView1.SelectedRows[0].Cells["ReportPath"].Value.ToString();
            Form3 form = new Form3(path);
            //ReportDocument crystal = new ReportDocument();
            //crystal.Load(dataGridView1.SelectedRows[0].Cells["ReportPath"].Value.ToString());
            //pass = crystal;
            form.Show();
        }
