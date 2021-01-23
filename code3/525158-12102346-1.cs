    protected void Page_Load(object sender, EventArgs e)
            {
                for (int i = 0; i < GridView1.Columns.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        GridView1.Columns[i].ItemStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        GridView1.Columns[i].ItemStyle.BackColor = Color.Blue; ;
                    }
                }
            }
