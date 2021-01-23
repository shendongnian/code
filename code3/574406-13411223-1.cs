    void sendMethod()
    {
        MethodInvoker mi = delegate{
           string lblText = (String)MsgSender.sendSMS(to, msg, "hotmail", uname, pwd);
           pictureBox1.Visible = false;
           lblMsgStatus.Visible = true;
           lblMsgStatus.Text = lblText + "\nFrom: " + uname + " To: " +             cmbxNumber.SelectedItem + " " + count;
       }; 
        if(InvokeRequired)
           this.Invoke(mi);
    }
