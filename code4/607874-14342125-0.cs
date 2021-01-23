            private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
            {
                if (dataGridView1.IsCurrentCellDirty)
                {
                    SqlCommandBuilder querybuilder = new SqlCommandBuilder(loginTableAdapter);
                    querybuilder.GetUpdateCommand();
                    loginTableAdapter.Update(dataset11);
                }
            }
            
            //or if you has a bindingSource
            private void bindingSource1_CurrentItemChanged(object sender, EventArgs e)
            {
                if (dataGridView1.IsCurrentCellDirty)
                {
                    SqlCommandBuilder querybuilder = new SqlCommandBuilder(loginTableAdapter);
                    querybuilder.GetUpdateCommand();
                    loginTableAdapter.Update(dataset11);
                }
            }
