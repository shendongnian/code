    OleDbCommand sCommand;
        OleDbDataAdapter sAdapter;
        OleDbCommandBuilder sBuilder;
        OleDbConnection connection;
        DataSet sDs;
        DataTable sTable;
        string myMode = "";
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM [Table]";
            connection = new OleDbConnection(connectionString);
            connection.Open();
            sCommand = new OleDbCommand(query, connection);
            sAdapter = new OleDbDataAdapter(sCommand);
            sBuilder = new OleDbCommandBuilder(sAdapter);
            sDs = new DataSet();
            sAdapter.Fill(sDs, "Table");
            sTable = sDs.Tables["Table"];
            connection.Close();
            DataGrid.DataSource = sTable;
            DataGrid.ReadOnly = true;
            DataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DataGrid.ReadOnly = false;
            myMode = "add";
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            DataGrid.ReadOnly = false;
            myMode = "edit";
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            myMode = "";
            if (MessageBox.Show("Do you want to delete this row ?", "Delete",      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataGrid.Rows.RemoveAt(DataGrid.SelectedRows[0].Index);
                sAdapter.Update(sTable);
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (myMode == "add")
            {
                sAdapter.Update(sTable);
                MessageBox.Show("Prices Are Successfully Added.", "Saved.", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else if (myMode == "edit")
            {
                string query = "UPDATE Table_Name SET " +
                    "Column1 = '" + DataGrid.SelectedRows[0].Cells[0].Value.ToString() + "' ," +
                    "Column2 = " + DataGrid.SelecteddRows[0].Cells[1].Value.ToString() + ", " +
                    "WHERE CONDITION";
                connection = new OleDbConnection(connectionString);
                connection.Open();
                sCommand = new OleDbCommand(query, connection);
                sAdapter = new OleDbDataAdapter(sCommand);
                sBuilder = new OleDbCommandBuilder(sAdapter);
                sDs = new DataSet();
                sAdapter.Fill(sDs, "Table");
                sTable = sDs.Tables["Table"];
                connection.Close();
                DataGrid.DataSource = sTable;
                DataGrid.ReadOnly = true;
            }
        }
