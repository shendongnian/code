    try
    {
     s.Send(m);
    }
    finally
    {
    
                lblCorrectCode.Text = "Contact Form Has been submited we will be in touch shortly";
    
                name.Text = string.Empty;
                phone.Text = string.Empty;
                email.Text = string.Empty;
                message.Text = string.Empty;
    }
