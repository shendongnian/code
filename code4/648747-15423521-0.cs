               if (String.IsNullOrEmpty(TextBox_ID.Text.ToString()))
                {
                    lbl_NoBatchID.Text = "Please enter BatchID!";
                    GridView1.DataSource=null;
                    GridView1.DataBind();
                }
                else
                {
