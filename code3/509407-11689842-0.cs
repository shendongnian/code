        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["SomeKey"] = TextBox1.Text;
            Response.Redirect("WebForm2.aspx"); 
        }
