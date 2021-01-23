        private void button1_Click(object sender, EventArgs e)
        {
            Article selectedArticle = list.Where(Articleid => Articleid.Id == int.Parse(comboBox1.SelectedValue.ToString())).FirstOrDefault();
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = selectedArticle.Id;
            row.Cells[1].Value = selectedArticle.Id2;
            row.Cells[2].Value = selectedArticle.Group;
            row.Cells[3].Value = selectedArticle.Code;
            row.Cells[4].Value = selectedArticle.Name;
            row.Cells[5].Value = selectedArticle.Price;
            dataGridView1.Rows.Add(row);
        }
 
