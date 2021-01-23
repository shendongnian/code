        private void button9_Click(object sender, EventArgs e)
        {
            FilterDataGrid();
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            FilterDataGrid();
        }
        private void FilterDataGrid()
        {
            var _text = Convert.ToString(textBox2.Text);
            var _comboText = ! string.IsNullOrEmpty(comboBox1.Text) ? Convert.ToString(comboBox1.SelectedItem) : string.Empty;
            var result = list3.Where(Srodek => Srodek.Srodek.category1 == _comboText || Srodek.Srodek.ID.Device == _text).ToList();
            //
            dataGridView4.DataSource = result;
        }
