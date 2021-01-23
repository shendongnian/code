    OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + Server.MapPath("path to DB"));
            string str = "update table set PersonType = ?, FirstName = ?, LastName = ?, Address = ?, Country = ?, Phone = ?, Fax = ?, Clinic = ?, ReferingFactor = ?, WebSite = ?, Receipt = ?, DeviceType = ?, DeviceSerialNumber = ?, PaymentType = ?, DevicePrice = ?,PersonUserName = ?, PersonPassword = ?, Comment = ? where ID = ?";
            using (conn)
            {
                using (OleDbCommand cmd = new OleDbCommand(str, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    
                    cmd.Parameters.AddWithValue("FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("LastName", lastName);
                    .
                    .
                    .
                }
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
