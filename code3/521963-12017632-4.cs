      Panel myPanel = new Panel();
        myPanel.ID = "myPanel";
        TextBox t = new TextBox();
        t.ID = "myTextBox";
        myPanel.Controls.Add(t);
        TextBox t1 = new TextBox();
        t1.ID = "myTextBox1";
        myPanel.Controls.Add(t1);
        
        // Add all your child controls to your panel and at the end add your panel to your form
        form1.Controls.Add(myPanel);
       // on the processing page you can get the values as
      protected void Page_Load(object sender, EventArgs e)
      {
 
        if (PreviousPage != null)
        {
            TextBox t = (TextBox) PreviousPage.FindControl("myTextBox");
            string mytboxvalue = t.Text;
        }
        string myTextBoxValue = Request.Form["myTextBox1"];
      }
