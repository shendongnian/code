    smtpsvr.SendCompleted += (sender,e) => 
    {
    if (e.Error != null) //error
            {
                sendResult = "email failed " + (string)e.UserState;
            }
            else
            {   //this result, indicate the process of sending email has been completed
                sendResult = "email sent " + (string)e.UserState;
            }
    }
