        Label[] lblc = new Label[10];
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                lblc[i] = new Label();
                this.Controls.Add(lblc[i]);
                if (Session["lblc" + i.ToString()] == null)
                    Session["lblc" + i.ToString()] = lblc[i].Text = (i + 1).ToString();
                else
                    lblc[i].Text = (string)Session["lblc" + i.ToString()];
            }
          
