                for (int i = 1; i <= 5; i++)
                {
                    TextBox tb = new TextBox();
                    tb.ID = "textbox" + i.ToString();
                    tb.Attributes.Add("runat", "server");
                    MyPanel.Controls.Add(tb);
                }
        }
       
        protected void btnReadTextBoxValue_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <=5; i++)
            {
    //Append the master page content place holder id with textbox then it find value and      work
                string str ="ctl00$ContentPlaceHolder3$"+"textbox" + i.ToString();
                TextBox retrievedTextBox = FindControl(str) as TextBox;
            if (retrievedTextBox != null)
            {
                lblResult.Text = ((TextBox)retrievedTextBox).Text;
                break;
            }
            else
            {
                lblResult.Text = "No text box has been created!";
            }
            }
