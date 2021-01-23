    public void button_click(object sender, EventArgs e)
    {
        string email = "";
        foreach (GridViewRow item in GridView1.Rows)
        {
    
              //if not, replace it with correct index
              email =  item.Cells[4].Text;
              //code to send email
             //reciever email add
             MailAddress to = new MailAddress(email);
             //sender email address
             MailAddress from = new MailAddress("your@email");
    
            MailMessage msg = new MailMessage();
            //use reason shown in grid
            msg.Subject = item.Cells[3].Text;
            //you can similar extract FName, LName, Account number from grid
            // and use it in your message body
            //Keep your message body like 
            str email_msg = "Dear {0} {1}, Your cheque for account number {2} bounced because of    the reason {3}";
            msg = String.Format(email_msg , item.Cells[0].Text,item.Cells[1].Text,item.Cells[2].Text,item.Cells[3].Text);
            msg.Body = email_msg ;
            msg.From = from;
            msg.To.Add(to);
    
            SendEMail(msg);
        
        }
    }
