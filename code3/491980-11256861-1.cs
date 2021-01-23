    StringBuilder sb = new StringBuilder();
    foreach (GridViewRow row in GridView1.Rows)
            {
                var chk = row.FindControl("myCheckBox") as CheckBox;
                if (chk.Checked)
                {
                var email = row.FindControl("LabelEmail") as Label;
                sb.Append(email.Text);
                sb.Append(",");
                }
