    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(DateTime.Now.ToString());
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        Table tblTextboxes = new Table();
        for (int i = 0; i < 10; i++)
        {
            TableRow tr = new TableRow();
            TableCell tc = new TableCell();
            TextBox tb = new TextBox();
            tb.ID = i.ToString();
            tc.Controls.Add(tb);
            tr.Cells.Add(tc);
            //TableCell tc1 = new TableCell();
            //LinkButton lnk = new LinkButton();
            //lnk.ID = i.ToString() + tb.Text + "lnk";
            //lnk.Text = "Show";
            //lnk.Click += new EventHandler(lnk_Click);
            //tc1.Controls.Add(lnk);
            //tr.Cells.Add(tc1);
            tblTextboxes.Rows.Add(tr);
        }
        placeTest.Controls.Add(tblTextboxes);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
    }
