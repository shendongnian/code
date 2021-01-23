         void addfooter(int rcount)
    {
        if (GridView1.BottomPagerRow == null)
        {
            return;
        }
        Panel p = (Panel)GridView1.BottomPagerRow.FindControl("gvpanel");
        DropDownList dd = (DropDownList)p.FindControl("ddpage");
        for (int i = 0; i < rcount; i++)
        {
            ListItem li = new ListItem();
            li.Text = (i + 1).ToString();
            li.Value = (i + 1).ToString();
            dd.Items.Add(li);
        }
        Label lbltot = (Label)p.FindControl("lbltot");
        lbltot.Text = GridView1.PageCount.ToString();
        dd.SelectedIndex = GridView1.PageIndex;
        LinkButton lbp10 = (LinkButton)p.FindControl("lbp10");
        lbp10.Enabled = false;
        lbp10.CssClass = "smalllinkbuttonfd";
        LinkButton lbp = (LinkButton)p.FindControl("lbp");
        lbp.Enabled = false;
        lbp.CssClass = "smalllinkbuttonfd";
        LinkButton lbn10 = (LinkButton)p.FindControl("lbn10");
        lbn10.Enabled = false;
        LinkButton lbn = (LinkButton)p.FindControl("lbn");
        lbn.CssClass = "smalllinkbuttonfd";
        lbn.Enabled = false;
        lbn10.CssClass = "smalllinkbuttonfd";
        int cpage = GridView1.PageIndex + 1;
        int totpage = GridView1.PageCount;
        if (cpage > 10)
        {
            lbp10.Enabled = true;
            lbp10.CssClass = "smalllinkbuttonf";
        }
        if (cpage > 1)
        {
            lbp.Enabled = true;
            lbp.CssClass = "smalllinkbuttonf";
        }
        if (cpage < totpage)
        {
            lbn.Enabled = true;
            lbn.CssClass = "smalllinkbuttonf";
        }
        if (cpage + 10 < totpage)
        {
            lbn10.Enabled = true;
            lbn10.CssClass = "smalllinkbuttonf";
        }
        for (int i = 1; i < 11; i++)
        {
            LinkButton lb = (LinkButton)p.FindControl("lb" + i.ToString());
            lb.Enabled = false;
            lb.CssClass = "smalllinkbuttonfd";
        }
        int tstart = cpage / 10;
        int lcount = tstart + 10;
        //int scount = tstart - 10;
        int cnt = 1;
        for (int i = (tstart * 10); i <= ((tstart * 10) + 10); i++)
        {
            if (cnt > 10)
            {
                return;
            } if ((i + 1) > totpage)
            {
                LinkButton lb = (LinkButton)p.FindControl("lb" + cnt.ToString());
                lb.Enabled = false;
                lb.Text = (i + 1).ToString();
                lb.CssClass = "smalllinkbuttonfd";
                cnt++;
            }
            else
            {
                if ((i + 1) == cpage)
                {
                    LinkButton lb = (LinkButton)p.FindControl("lb" + cnt.ToString());
                    lb.Enabled = false;
                    lb.Text = (i + 1).ToString();
                    lb.CssClass = "smalllinkbuttonfd";
                    cnt++;
                }
                else
                {
                    LinkButton lb = (LinkButton)p.FindControl("lb" + cnt.ToString());
                    lb.Enabled = true;
                    lb.Text = (i + 1).ToString();
                    lb.CssClass = "smalllinkbuttonf";
                    cnt++;
                }
            }
        }
    }
