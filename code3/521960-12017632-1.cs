     // Page2.aspx.cs
     protected void Page_Load(object sender, EventArgs e)
     {       
        if (PreviousPage != null)
        {
            TextBox t = (TextBox) PreviousPage.FindControl("myTextBox");
            string mytboxvalue = t.Text;
        }
                            // OR
        string myTextBoxValue = Request.Form["myTextBox"];
     }
