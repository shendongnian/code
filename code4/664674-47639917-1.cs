            if (MessageBox.Show("Sure you wanna delete?", "Warning", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                //get the index from the dataGridView
                int rowIndex = table1DataGridView.CurrentCell.RowIndex;
                //Remove from both the actual database & datagridview
                table1BindingSource.RemoveAt(rowIndex);
                //update table 1
                this.table1TableAdapter.Update(this.maquinasDataSet.Table1);
                //load table 1
                this.table1TableAdapter.Fill(this.maquinasDataSet.Table1);
            }
