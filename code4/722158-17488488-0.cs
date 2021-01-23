    protected void Button2_Click(object sender, EventArgs e)
         {
           TextBox txt = new TextBox();  //add this line
           TextBox txt = Panel1.FindControl("myText") as TextBox;
           Response.Write(txt.Text);
         }
