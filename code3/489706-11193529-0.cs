            int userDeleteIndex;
            if (int.TryParse(datagridview.Rows[rowIndex].Cells[0].Value.ToString(), out userDeleteIndex))
            {
                if (MessageBox.Show("Delete " + recordidentifyingdata + "? ", "Delete " + userDeleteIndex.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string updateUserSql = "DELETE FROM table WHERE user_id = " + userDeleteIndex.ToString() + "; ";
                        dtCommand.UpdateTable(updateUserSql);
                        InitializeUserDataView();
                        // Initalize userdataview refreshes the datagridview with the updated info
                    }
                    catch (Exception err)
                    {
                       Error trapping goes here
                    }
