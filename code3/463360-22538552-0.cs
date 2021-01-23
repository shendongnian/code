    SqlCommand command = new SqlCommand("UPDATE users SET status = 1 WHERE status=0;", kapcsolat);
            command.ExecuteNonQuery();
            //folyamat();
            string hely = @"C:\xampp\FileZillaFTP\FileZilla Server.xml";
            try
            {
                StreamWriter wr = new StreamWriter(hely, false);
                wr.WriteLine("<FileZillaServer>");
                wr.WriteLine("      <Settings>");
                wr.WriteLine("      <Item name=\"Admin port\" type=\"numeric\">14147</Item>");
                wr.WriteLine("    </Settings>");
                wr.WriteLine("  <Groups />");
                wr.WriteLine("  <Users>");
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    DirectoryInfo di = Directory.CreateDirectory(@"C:\\FTPUsers\" + dataGridView1.Rows[i].Cells[0].Value);
                    wr.WriteLine(" <User Name=\"" + dataGridView1.Rows[i].Cells[0].Value + "\">");
                    wr.WriteLine("      <Option Name=\"Pass\">" + dataGridView1.Rows[i].Cells[1].Value + "</Option>");
                    wr.WriteLine("      <Option Name=\"Group\"></Option>");
                    wr.WriteLine("      <Option Name=\"Bypass server userlimit\">0</Option>");
                    wr.WriteLine("       <Option Name=\"User Limit\">0</Option>");
                    wr.WriteLine("      <Option Name=\"IP Limit\">0</Option>");
                    wr.WriteLine("      <Option Name=\"Enabled\">1</Option>");
                    wr.WriteLine("      <Option Name=\"Comments\"></Option>");
                    wr.WriteLine("      <Option Name=\"ForceSsl\">0</Option>");
                    wr.WriteLine("   <IpFilter>");
                    wr.WriteLine("      <Disallowed />");
                    wr.WriteLine("      <Allowed />");
                    wr.WriteLine("  </IpFilter>");
                    wr.WriteLine("  <Permissions>");
                    wr.WriteLine("      <Permission Dir=\"C:\\FTPUsers\\" + dataGridView1.Rows[i].Cells[0].Value + "\">");
                    wr.WriteLine("      <Option Name=\"FileRead\">1</Option>");
                    wr.WriteLine("      <Option Name=\"FileWrite\">1</Option>");
                    wr.WriteLine("      <Option Name=\"FileDelete\">1</Option>");
                    wr.WriteLine("      <Option Name=\"FileAppend\">1</Option>");
                    wr.WriteLine("      <Option Name=\"DirCreate\">1</Option>");
                    wr.WriteLine("      <Option Name=\"DirDelete\">1</Option>");
                    wr.WriteLine("      <Option Name=\"DirList\">1</Option>");
                    wr.WriteLine("      <Option Name=\"DirSubdirs\">1</Option>");
                    wr.WriteLine("      <Option Name=\"IsHome\">1</Option>");
                    wr.WriteLine("      <Option Name=\"AutoCreate\">0</Option>");
                    wr.WriteLine("    </Permission>");
                    wr.WriteLine("  </Permissions>");
                    wr.WriteLine("<SpeedLimits DlType=\"0\" DlLimit=\"10\" ServerDlLimitBypass=\"0\" UlType=\"0\" UlLimit=\"10\" ServerUlLimitBypass=\"0\">");
                    wr.WriteLine("              <Download />");
                    wr.WriteLine("          <Upload />");
                    wr.WriteLine("      </SpeedLimits>");
                    wr.WriteLine("</User>");
                }
                wr.WriteLine("  </Users>");
                wr.WriteLine("</FileZillaServer>");
                wr.Close();
