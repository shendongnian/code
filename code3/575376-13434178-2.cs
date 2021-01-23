    private void btnBack_Click(object sender, EventArgs e)
        {
            if (pnlContent2.Visible) { ShowPanel("1"); return; }
            if (pnlContent3.Visible) { ShowPanel("2"); return; }
            if (pnlContent4.Visible) { ShowPanel("3"); return; }
            if (pnlContent5.Visible) { ShowPanel("4"); return; }
        }
