            public void MessageBox(string message, Page page)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Label lbl = new Label();
                lbl.Text = "<script type=\"text/javascript\" language=\"javascript\">" + "alert('" + message + "'); " + "</script>";
                page.Controls.Add(lbl);
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            MessageBox("test", Page);
        } 
