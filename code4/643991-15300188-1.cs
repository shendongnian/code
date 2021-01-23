    Control[] aryCtrl = new Control[] { 
                                       txtName, 
                                       cbxCreditCardName, 
                                       txtAmount, 
                                       txtMessage };
    var recipients = new List<Recipient>();
    private void button1_Click(object sender, EventArgs e)
    {
        if (recipients.Count < 5)
        {
           var recipient = new Recipient();
       
           recipient.Name = txtName.Text;
           recipient.CreditCardName = cbxCreditCardName.SelectedValue;
           recipient.CreditCardNumber = txtCreditCardNumber.Text;
           recipient.Amount= txtAmount.Text;
           recipient.Message= txtMessage.Text;
           recipients.Add(recipient);
        }
        else {
             //Provide user with message telling them that they can only have up to 5 recipients.
        }
    }
