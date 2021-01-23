        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                moveUp();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                moveDown();
            }
        }
        private void moveUp()
        {
            if (dataGridView1.RowCount > 0)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    if ((index - 1) > 0)
                    {
                        dataGridView1.Rows[index].Selected = false;
                        dataGridView1.Rows[index - 1].Selected = true;
                    }
                    else
                    {
                        dataGridView1.Rows[index].Selected = true;
                    }
                }
            }
        }
        private void moveDown()
        {
            if (dataGridView1.RowCount > 0)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    if ((index + 1) < dataGridView1.RowCount)
                    {
                        dataGridView1.Rows[index].Selected = false;
                        dataGridView1.Rows[index + 1].Selected = true;
                    }
                    else
                    {
                        dataGridView1.Rows[index].Selected = true;
                    }
                }
            }
        }
