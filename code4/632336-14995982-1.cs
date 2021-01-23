        protected void DeleteClick(object sender,EventArgs e)
        {
            for (int i=0; i < GridView1.Rows.Count;i++)
            {
                CheckBox chkDelete = GridView1.Rows[i].FindControl("chkDelete") as CheckBox;
                if (chkDelete != null && chkDelete.Checked)
                {
                    //Delete the item
                }
            }
        }
