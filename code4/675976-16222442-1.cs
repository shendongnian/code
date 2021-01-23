    private void btnSyntaxCheck_Click(object sender, EventArgs e)
            {
                try
                {
                    tsStatus.Text = "Checking Syntax...";
                    LogMessage(DA_Base.Constants.ERROR_LEVEL_DEBUG, "SQLScripting::SyntaxCheck", "Query: " + rtbScript.Text);
                     String scriptAndStub; 
                     scriptAndStub = "DECLARE @SA_CONSOLE_HOSTNAME VARCHAR(256)\n";
                                        
                    using (SqlCommand myCommand = new SqlCommand(string.Empty, Connection))
                    {
                       foreach (string script in Regex.Split(rtbScript.Text, "^GO\r?$", RegexOptions.Multiline | RegexOptions.IgnoreCase))
                          {
                               if (!String.IsNullOrEmpty(script))
                               {
                                 myCommand.CommandText = "SET PARSEONLY ON\n" + script;
                                 myCommand.ExecuteNonQuery();
                                }
                           }
                     }
                     tsStatus.Text = "Checking Syntax Complete. No errors reported.";
                 }
                 catch (Exception exc)  \\error has been caught here....
                 {
                    tsStatus.Text = exc.Message;
                    MessageBox.Show(exc.Message, "SQL Syntax Check");
                 }
             }
       }
    } 
