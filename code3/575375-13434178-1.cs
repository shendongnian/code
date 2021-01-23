    private void btnNext_Click(object sender, EventArgs e)
        {
            if (pnlContent1.Visible) { ShowPanel("2"); return; }
            if (pnlContent2.Visible) { ShowPanel("3"); return; }
            if (pnlContent3.Visible) { ShowPanel("4"); return; }
            if (pnlContent4.Visible) { ShowPanel("5"); return; }
        }
