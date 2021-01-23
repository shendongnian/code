        private void dgv_RowValidating( object sender, DataGridViewCellCancelEventArgs e )
        {
            try
            {
                if (!dgv.IsCurrentRowDirty)
                    return;
                string query = GetInsertOrUpdateSql(e);
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();
                var cmd = new SqlCommand( query, _conn );
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            }
        }
        public string GetInsertOrUpdateSql( DataGridViewCellCancelEventArgs e )
        {
            DataGridViewRow row = dgv.Rows[e.RowIndex];
            int id = 0;
            int.TryParse( row.Cells["Id"].Value.ToString(), out id );
                
            DateTime dob;
            DateTime.TryParse( row.Cells["Dob"].Value.ToString(), out dob );
            string email = row.Cells["Email"].Value.ToString();
            string phone = row.Cells["Phone"].Value.ToString();
            string fio = row.Cells["Fio"].Value.ToString();
            if (id == 0)
                return string.Format( "insert into {0}  Values ('{1}','{2}','{3}','{4}')", "dbo.People", fio, dob.ToString( "dd-MM-yyyy" ), email, phone );
            else
                return string.Format( "update {0} set Fio='{1}', Dob='{2}', Email='{3}', Phone='{4}' WHERE Id={5}", C.Table, fio, dob.ToString( "dd-MM-yyyy" ), email, phone, id );
        }
        private void dgv_UserDeletingRow( object sender, DataGridViewRowCancelEventArgs e )
        {
            try
            {
                int id = 0;
                int.TryParse( e.Row.Cells["Id"].Value.ToString(), out id );
                string query = string.Format( "DELETE FROM {0} WHERE Id = {1}", "dbo.People", id );
                var cmd = new SqlCommand( query, _conn );
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            }
        }
