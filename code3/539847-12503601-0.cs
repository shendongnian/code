    public string getConnString()
            {
                //set the connection string from web config file
                return WebConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            }
    
            private void executeInsert()    
            {
                OleDbConnection conn = new OleDbConnection(getConnString());
                string sql = "INSERT INTO APPS.CLV_EVENT_TRACK (EVENTTYPE, EVENTSUBTYPE, DEPTNAME, EVENTDATE, DURATION, EVENTNAME, EVENTADD, WARDNO, PROGRAM, NUMATT, STARTTIME, ENDTIME, MNGNAME, RECORDKEEPER) ";
                sql += "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
    
                try
                {
                    var start = DateTime.Parse(txtStTime.Text);
                    var end = DateTime.Parse(txtEndTime.Text);
    
                    TimeSpan duration = end.Subtract(start);
                    string meetDuration = duration.TotalMinutes.ToString();
                    
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.Parameters.Add("?", OleDbType.VarChar).Value = rbEventType.SelectedItem.Text;
                        cmd.Parameters.Add("?", OleDbType.VarChar).Value = ddVolType.SelectedItem.Text;
                        cmd.Parameters.Add("?", OleDbType.VarChar).Value = txtDept.Text;
                        cmd.Parameters.Add("?", OleDbType.Date).Value = txtEventDate.Text;
                        cmd.Parameters.Add("?", OleDbType.Numeric).Value = meetDuration;
                        cmd.Parameters.Add("?", OleDbType.VarChar).Value = txtEventName.Text;
                        cmd.Parameters.Add("?", OleDbType.VarChar).Value = txtEventAdd.Text;
                        cmd.Parameters.Add("?", OleDbType.VarChar).Value = ddWard.SelectedItem.Value;
                        cmd.Parameters.Add("?", OleDbType.VarChar).Value = txtSBPlan.Text;
                        cmd.Parameters.Add("?", OleDbType.Numeric).Value = txtNumVol.Text;
                        cmd.Parameters.Add("?", OleDbType.Date).Value = txtStTime.Text;
                        cmd.Parameters.Add("?", OleDbType.Date).Value = txtEndTime.Text;
                        cmd.Parameters.Add("?", OleDbType.VarChar).Value = txtEventMgr.Text;
                        cmd.Parameters.Add("?", OleDbType.VarChar).Value = txtRecording.Text;
    
                        cmd.ExecuteNonQuery();
                    }
                }
    
                catch (Exception ex) { throw ex; }
    
                finally
                {
                    conn.Close();
                }
            }
    
            protected void btnSubmit_Click(object sender, EventArgs e)
            {
                executeInsert();
            }
