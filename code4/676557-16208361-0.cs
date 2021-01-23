    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        LinkButton btn = new LinkButton();
        btn.Click += LinkClicked;
        e.Cell.Controls.Add(btn);
    }
    private void LinkClicked(Object sender, EventArgs e)
    {
         LinkButton btn = (LinkButton) sender;
    }
