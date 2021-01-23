    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 20; i++)
        {
            GridView gv = new GridView();
            gv.ID = "_gridview" + i;
            Queue q = new Queue();
            q.Enqueue(i);
            gv.DataSource = q;
            gv.DataBind();
            ph.Controls.Add(gv);
        }
    }
