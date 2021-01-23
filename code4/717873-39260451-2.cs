     protected void Kaydet(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection("Data Source=XE;Persist Security Info=True;Password=*****;User ID=WINCELL");
            string procedure = "WINCELL_API.ADD_CAMPAIGN";
            OracleCommand cmd = new OracleCommand(procedure, conn);
            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter();
           
            string xml = "<campaign>";
            xml += "\n";
            xml += "<campaignInfo>";
            xml += "\n";
            xml += "<name>" + TextBox1.Text + "</name>";
            xml += "\n";
            xml += "<startDate>" + TextBox2.Text + "</startDate>";
            xml += "\n";
            xml += "<period>" + TextBox3.Text + "</period>";
            xml += "\n";
            xml += "<handsetStatu>" + TextBox4.Text + "</handsetStatu>";
            xml += "\n";
            xml += "<ServiceID>" + TextBox5.Text + "</ServiceID>";
            xml += "\n";
            xml += "</campaignInfo>";
            xml += "\n";
            xml += "</campaign>";
            TextBox6.Text = xml;
          
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter param = new OracleParameter();
                param.ParameterName = "";
                param.OracleDbType = OracleDbType.Clob;
                param.Value = xml;
                param.Direction = System.Data.ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                try
                {
                cmd.ExecuteNonQuery(); 
                }
                catch (Exception ex)
                {
                Label1.Text = error" + ex.ToString();
                   
                }
            //string str = (param.Value as OracleClob).Value;
            //Label1.Text = "val: " + str;
        }
