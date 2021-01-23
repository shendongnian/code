    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    MemoryStream ms = new MemoryStream(dataGridView1.SelectedRows[0].Cells["Picture"].Value);
                    pictureBox2.Image = Image.FromStream(ms);
                }
            }
