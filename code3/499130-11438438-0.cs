            //now delete inserted row from SQL table            
            string DELETE = "DELETE FROM " + tbTable_DAQ.Text + " ";
            string FROM = "WHERE " + "Date = @Date" + " AND " + "Time = @Time" + " AND " + "Comment = @Comment";
            string SQL_DeleteString = DELETE + FROM;
            try
            {
               //create SQL command object
               SqlCommand SQL_Delete = new SqlCommand(SQL_DeleteString, SQL_Connection);
               //attach values
               SQL_Delete.Parameters.AddWithValue("@Date",               DateTimeNow.Date);
               SQL_Delete.Parameters.AddWithValue("@Time",               DateTimeNow.TimeOfDay);
               SQL_Delete.Parameters.AddWithValue("@Comment",            "Table Access Test.");
               SQL_Delete.ExecuteNonQuery();
               //dispose & nullify SQL_Delete
               SQL_Delete.Dispose();
               SQL_Delete = null;
            }
            catch (Exception eDelete) { MessageBox.Show(eDelete.ToString(), "SQL DELETE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
