    protected void SendEmail(string toAddresses, string fromAddress, string MailSubject, string MessageBody, bool isBodyHtml)
        {
            SmtpClient sc = new SmtpClient("MAIL.Aramco.com");
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("pssp@aramco.com", "PMOD Safety Services Portal (PSSP)");
    
                // In case the mail system doesn't like no to recipients. This could be removed
                //msg.To.Add("pssp@aramco.com");
    
                msg.Bcc.Add(toAddresses);
                msg.Subject = MailSubject;
                msg.Body = MessageBody;
                msg.IsBodyHtml = isBodyHtml;
                //Response.Write(msg);
                sc.Send(msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
    
        }
    
        protected void SendEmailTOAllUser()
        {
            string connString = "Data Source=localhost\\sqlexpress;Initial Catalog=psspdbTest;Integrated Security=True";
    
            using (SqlConnection conn = new SqlConnection(connString))
            {
                var sbEmailAddresses = new System.Text.StringBuilder(2000);
                string quizid = "";
    
                // Open DB connection.
                conn.Open();
    
                string cmdText = "SELECT MIN (QuizID) As mQuizID FROM dbo.QUIZ WHERE IsSent <> 1";
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if(reader.Read())
                        {
                            // There is only 1 column, so just retrieve it using the ordinal position
                            quizid = reader["mQuizID"].ToString();
    
                        }
                    }
                    reader.Close();
                }
    
                string cmdText2 = "SELECT Username FROM dbo.employee";
                using (SqlCommand cmd = new SqlCommand(cmdText2, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            var sName = reader.GetString(0);
                            if (!string.IsNullOrEmpty(sName))
                            {
                                if (sbEmailAddresses.Length != 0)
                                {
                                    sbEmailAddresses.Append(",");
                                }
                                // Just use the ordinal position for the user name since there is only 1 column
                                sbEmailAddresses.Append(sName).Append("@aramco.com");
                            }
                        }
                    }
                    reader.Close();
                }
    
                string cmdText3 = "UPDATE dbo.Quiz SET IsSent = 1 WHERE QuizId = @QuizID";
                using (SqlCommand cmd = new SqlCommand(cmdText3, conn))
                {
                    // Add the parameter to the command
                    var oParameter = cmd.Parameters.Add("@QuizID", SqlDbType.Int);
    
                    var sEMailAddresses = sbEmailAddresses.ToString();
                    string link = "<a href='http://pmv/pssp/StartQuiz.aspx?testid=" + quizid + "'> Click here to participate </a>";
                    string body = @"Good day, <br /><br />
                                    <b> Please participate in the new short safety quiz </b>"
                                        + link +
                                        @"<br /><br />
                                Also, give yourself a chance to gain more safety culture by reading the PMOD Newsletter.
                                <br /> <br /><br /> <br />
                                This email was generated using the <a href='http://pmv/pssp/Default.aspx'>PMOD Safety Services Portal (PSSP) </a>. 
                                Please do not reply to this email.
                                ";
    
                    int sendCount = 0;
                    List<string> addressList = new List<string>(sEMailAddresses.Split(','));
                    StringBuilder addressesToSend = new StringBuilder();
    if(!string.IsNullOrEmpty(quizid )){
                    for (int userIndex = 0; userIndex < addressList.Count; userIndex++)
                    {
                        sendCount++;
                        if (addressesToSend.Length > 0)
                            addressesToSend.Append(",");
    
                        addressesToSend.Append(addressList[userIndex]);
                        if (sendCount == 10 || userIndex == addressList.Count - 1)
                        {
                            SendEmail(addressesToSend.ToString(), "", "Notification of New Weekly Safety Quiz", body, true);
                            addressesToSend.Clear();
                            sendCount = 0;
                        }
                    }
    }
    
                    // Update the parameter for the current quiz
                    oParameter.Value = quizid;
                    // And execute the command
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
