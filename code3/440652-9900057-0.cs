        using (SqlCeConnection con = new SqlCeConnection(@"Data Source=C:\Documents and Settings\Administrator\My Documents\Visual Studio 2008\Projects\TrackCon\TrackCon\BMSDATA.sdf;Persist Security Info = True;Password=Gdex123$"))
        {
                SqlCeCommand com = new SqlCeCommand("SELECT conno,cmpsno,ctrx,dsysdate,cstnno,corigin FROM BRDATA WHERE conno >= @startDate and conno < @endDate", con);
                com.Parameters.Add (new SqlCeParameter("@startDate", SqlDbType.DateTime, 
                        textbox1.Value.Date));
                com.Parameters.Add (new SqlCeParameter("@endDate", SqlDbType.DateTime, 
                        textbox1.Value.Date.AddDays(1)));
                SqlCeDataAdapter adap = new SqlCeDataAdapter(com);
                DataSet set = new DataSet();
                adap.Fill(set);
                if (set.Tables.Count > 0)
                {
                    bRDATABindingSource1.DataSource = set.Tables[0];
                }
                bRDATABindingSource1.Filter = null;
                dataGridView1.DataSource = bRDATABindingSource1;
                con.Close();
        }
