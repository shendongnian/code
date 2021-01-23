    private bool UserHasBooking(int userId, int eventID)
    {
        bool result = false;
    
    string connString = "Data Source=localhost\\sqlexpress;Initial Catalog=RegistrationSysDB;Integrated Security=True;";
    string selectCommand = "SELECT count(*) as UserBookingsCount FROM BookingDetails WHERE NetworkID = NetworkID AND EventID = @EventID";
    using (SqlConnection conn = new SqlConnection(connString))
    {
        //Open DB Connection
        conn.Open();
        using (SqlCommand cmd = new SqlCommand(selectCommand, conn))
        {
            cmd.Parameters.AddWithValue("@EventID", eventID);
            cmd.Parameters.AddWithValue("@NetworkID", userId);
            if ((int)cmd.ExecuteScalar() > 0)
            {
                result = true;
            }
        }
        //Close the connection
        conn.Close();
    }
    
        return result;
    }
    protected void btnSendConfirmationEmail_Click(object sender, EventArgs e)
        {
            int eventID = Convert.ToInt32(HiddenField1.Value);
            if(!UserHasBooking(userNetworkID, eventID))
            {
    
            checkUserID(userNetworkID);
    
    
            SmtpClient sc = new SmtpClient("MAIL.Aramco.com");
            StringBuilder sb = new StringBuilder();
            MailMessage msg = new MailMessage();
    
    
            //Variables for retrieving the Booking Information
            string title = lblTitle.Text;
            string description = lblDescription.Text;
            string location = lblLocation.Text;
            string startDateTime = lblStartDateTime.Text;
            string endDateTime = lblEndDateTime.Text;
    
            //Message Information
            string toAddress = userNetworkID + "@aramco.com";
            string fromAddress = "erms@aramco.com";
            string mailSubject = "Registration Notification";
            string messageBody = @"Greetings, <br /><br />
                                   Your booking information is as following: <br /><br />
                                   <b><u>Event Details</u></b> <br /><br />
                                   <b>Title: </b>" + title +
                                   "<br /> <b>Description: </b>" + description +
                                   "<br /> <b>Location: </b>" + location +
                                   "<br /> <b>Start Date & Time: </b>" + startDateTime +
                                   "<br /> <b>End Date & Time: </b>" + endDateTime +
                                   @"<br /><br /><br /><br /> 
                                     This email was generated using the <a href='http://pmv/PM_Registration_System/Default.aspx'>Events Registration Management System (ERMS) </a>. 
                                     Please do not reply to this email.";
    
            try
            {
                msg.To.Add(toAddress);
                msg.From = new MailAddress(fromAddress, "Events Registration Management System");
                msg.Subject = mailSubject;
                msg.Body = messageBody;
                msg.IsBodyHtml = true;
    
                sc.Send(msg);
            }
    
            catch (Exception ex)
            {
                throw ex;
                // something bad happened
                //Response.Write("Something bad happened!");
    
            }
    
            finally
            {
    
                if (msg != null)
                {
                    msg.Dispose();
                }
    
            }
    
           }
    
        }
