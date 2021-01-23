    private bool _isStop = false;
    protected void Button_Click(object sender, EventArgs e)
    {
        string search= txtSearch.Text;
        for (int i= 0; i< MyGridView.PageCount; i++)
        {
            MyGridView.PageIndex = i;
            //MyGridView populate page here (MyGridView_View(sender, e))
            for (int j=0; j< MyGridView.Rows.Count; j++)
            {
                GridViewRow row = MyGridView.Rows[j];
                if (row.Cells[2].Text.Contains(search)) // cell[2] is personal code as you said.
                {
                    _isStop = true;
                    row.ForeColor = ColorTranslator.FromHtml("red");
                    break;
                }
            }
            if (flag)
                break;
        }
        if (!flag)
            MyGridView.PageIndex = 0;
            //MyGridView_View(sender, e)
    }
