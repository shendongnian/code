    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                foreach (ListItem li in ListBox1.Items)
                {
                    if (li.Selected == true)
                    {
                        // what ever you want to assign to TextBox 
                        this.TextBox1.Text = li.Text + "First Name"; // (row["NameFirst"]).ToString();
                        this.TextBox2.Text = li.Text + "Last Name";
                        this.TextBox3.Text = li.Text + "Email";
                    }
                }
            }
