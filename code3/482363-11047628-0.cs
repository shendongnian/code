        private bool RecordExists(string name, DateTime date, string time)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            //query for duplicate
            cmd.CommandText = "select count(*) from Booking where sname = @newName and bdate = @newDate and btime = @newTime";
            cmd.Parameters.Add("@newName", OleDbType.VarChar).Value = txt_cname.Text;
            cmd.Parameters.Add("@newDate", OleDbType.DBDate).Value = dtp_bdate.Value.Date;
            cmd.Parameters.Add("@newTime", OleDbType.VarChar).Value = dtp_btime.Value.ToString("hh:mm tt");
            myCon.Open();
            int recordCount = Convert.ToInt32(cmd.ExecuteScalar());
            myCon.Close();
            return recordCount > 0;
        }
        
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (RecordExists(txt_cname.Text, dtp_bdate.Value.Date, dtp_btime.Value.ToString("hh:mm tt"))
            {
                MessageBox.Show("Duplicated", "My Application", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                return;
            }
            
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Booking(cname, bdate, btime, ccontact, sname) Values(@newName, @newDate, @newTime, @newContact, @newSName)";
            cmd.Parameters.Add("@newName", OleDbType.VarChar).Value = txt_cname.Text;
            cmd.Parameters.Add("@newDate", OleDbType.DBDate).Value = dtp_bdate.Value.Date;
            cmd.Parameters.Add("@newTime", OleDbType.VarChar).Value = dtp_btime.Value.ToString("hh:mm tt");
            cmd.Parameters.Add("@newContact", OleDbType.VarChar).Value = txt_ccontact.Text;
            cmd.Parameters.Add("@newSName", OleDbType.VarChar).Value = txt_sname.Text;
            cmd.Connection = myCon;
            myCon.Open();
            cmd.ExecuteNonQuery();
            myCon.Close();
            MessageBox.Show(dtp_bdate.Value.ToString());
            MessageBox.Show("Booking completed", "My Application", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }
