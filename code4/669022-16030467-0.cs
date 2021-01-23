     protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < GridView1.Rows.Count; j++)
            {
                UpdatePanel up1 = GridView1.Rows[j].FindControl("updatepanel1") as UpdatePanel;
                TextBox tb1 = up1.FindControl("TextBox1") as TextBox;
                CheckBoxList cb1 = up1.FindControl("CheckBoxList1") as CheckBoxList;
                string name = "";
                for (int i = 0; i < cb1.Items.Count; i++)
                {
                    if (cb1.Items[i].Selected)
                    {
                        name += cb1.Items[i].Text + ",";
                    }
                }
                tb1.Text = name;
            }
        }
