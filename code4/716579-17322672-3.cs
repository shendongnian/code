        protected void btnReceive_Click(object sender, EventArgs e)
        {
                int X = int.Parse(ViewState["X"].ToString());
                int Y = int.Parse(ViewState["Y"].ToString());
                if (Y < GridView1.Rows.Count )
                {
                    GridView1.Rows[X - Y].Visible = false;
                    ViewState["Y"] = Y + 1; 
                }
        }
