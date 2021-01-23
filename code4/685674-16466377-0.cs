    public void Button_Click(object sender,EventArgs e)
    { 
          var myButton = (Button)sender;
          int id = Convert.ToInt32(myButton.Tag);
    }
