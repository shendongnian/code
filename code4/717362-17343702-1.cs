     protected void Button1_Click(object sender, EventArgs e)
     {
         string s1 = TextBox1.Text;
         string s11 = HttpUtility.UrlEncode(s1);
         Response.Redirect("WebForm2.aspx?&Name=" + s11));
     }
