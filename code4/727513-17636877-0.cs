            private void deleteButton_Click(object sender, EventArgs e)
             
             {
            
            OleDbConnection myConn = new OleDbConnection(connectionString);
            string excelDelete = "DELETE FROM [Sheet1$] WHERE ID = '" + dgvExcelList["ID", dgvExcelList.CurrentRow.Index].Value.ToString() + "'";//modify as your need
            OleDbCommand Deletecmd = new OleDbCommand(excelDelete, myConn);
            myConn.Open();
            Deletecmd.ExecuteNonQuery();
            myConn.Close();
            /*code to update datagridview*/
            
        }
