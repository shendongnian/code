        Int32 i;
        CheckBox k;
        for (i = 0; i < GridView1.Rows.Count; i++)
            {
                k = ((CheckBox)(GridView1.Rows[i].Cells[0].FindControl("chk")));
                if (k.Checked == true)
                {
                    //your code here
                }
                else
                {
                    //your code here
                }
            }
