    protected void Page_Load(object sender, EventArgs e)
            {
                populate();
            }
            public void populate()
            {
                for (int i = 0; i < 3; i++)
                {
                    TextBox tb = new TextBox();
                    tb.ID = "s" + i;
                    tb.Text = "Hello" + i;
                    plcholder.Controls.Add(tb);
                }
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                int cont = plcholder.Controls.Count;
                for (int i = 0; i < cont-1; i++)
                {
                    TextBox tx = (TextBox)plcholder.FindControl("s" + i);
                    Response.Write(tx.Text);
                }
            }
