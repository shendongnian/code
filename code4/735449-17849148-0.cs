     protected void AddTxt(object sender, EventArgs e)
    {
        add();
    }
    private void add()
    {
        int tblRows = 3;
        int tblCols = 3;
        Table tbl = new Table();
        for (int i = 0; i < tblRows; i++)
        {
            TableRow tr = new TableRow();
            for (int j = 0; j < tblCols; j++)
            {
                TableCell tc = new TableCell();
                TextBox txtBox = new TextBox();
                txtBox.ID = "txt" + i.ToString() + j.ToString();
                //txtBox.TextChanged += new EventHandler(txt_TextChanged);
                tc.Controls.Add(txtBox);
                tr.Cells.Add(tc);
                
            }
            tbl.Rows.Add(tr);
        }
        holder.Controls.Add(tbl);
        if (Session["ctls"] != null)
        {
            Session["ctls"] += ";t";
        }
        else
        {
            Session["ctls"] = "t";
        }
        panel.Update();
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        if (Session["ctls"] != null)
        {
            string[] ctls = Session["ctls"].ToString().Split(';');
            
            foreach (string ctlType in ctls)
            {
                if (string.Compare(ctlType, "t") == 0)
                {
                    add();
                }
            }
        }
    }
