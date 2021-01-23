    protected void btnredirect_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        switch (btn.ID)
        {
            case "check":
                {
                    for(int i=0;i<Gvshowcart.Rows.Count; i++)
                    {
                        CheckBox chl =     (CheckBox)Gvshowcart.Rows[i].Cells[0].FindControl("cheker");
                        if (chl != null)
                        {
                            if (chl.Checked == true)
                            {
                                chl.Checked = false;
                            }
                            else
                            {
                                chl.Checked = true;
                            }
                        }
                    }
                }
                break;
        }
   }
